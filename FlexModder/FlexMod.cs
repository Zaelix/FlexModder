using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexModder
{
    class FlexMod
    {
        String campPath;
        String mainRegistry;
        String itemRegistry;
        String blockRegistry;
        MainFormWindow mainWindow;

        public FlexMod(MainFormWindow mainWin) {
            this.mainWindow = mainWin;
        }

        public Object[] findInsertingSpace(String myFile, String name, String searchString, String insertString, int num, String fileContent)
        {
            int number_of_lines = 0;

            StreamReader sr = new StreamReader(myFile);

            String lineContents = "";
            lineContents = sr.ReadLine();
		    while (sr.Peek() >= 0)
            {
                if (number_of_lines >= num){
				    fileContent = fileContent + lineContents + "\n";
			    }
			    if (lineContents.Contains("// " + searchString + " --")){
				    fileContent = fileContent + insertString + "\n";
				    break;
			    }
                number_of_lines++;
			    lineContents = sr.ReadLine();
		    }
		    sr.Close();
		    Object[] values = new Object[] { fileContent, number_of_lines + 1 };
		    return values;
	    }

        public String finishRead(String myFile, int num, String fileContent)
        {

            int number_of_lines = 0;
            StreamReader sr = new StreamReader(myFile);

            String lineContents = "";
            lineContents = sr.ReadLine();
            while (sr.Peek() > -1)
            {
                if (number_of_lines >= num){
				    fileContent = fileContent + lineContents + "\n";
                }
                number_of_lines++;
                lineContents = sr.ReadLine();
            }
            fileContent = fileContent + lineContents + "\n";
            sr.Close();
		    return fileContent;
	    }

        public String findFiles()
        {
            String myPath;

            String testDrive = "E:/Desktop Stuff/Programming/ForgeMod Test Folder/";
            String dDrive = "D:/src/main/java/com/camp/";
            String eDrive = "E:/src/main/java/com/camp/";
            String fDrive = "F:/src/main/java/com/camp/";
            string[] drives = new string[4];
            drives[0] = testDrive;
            drives[1] = dDrive;
            drives[2] = eDrive;
            drives[3] = fDrive;

            string chosen = DisplaySources(drives);

            myPath = chosen != "" ? chosen : "No Paths Found";

            SetSources(myPath);

		    return myPath;
	    }

        public void SetSources(string path)
        {
            String testDrive = "E:/Desktop Stuff/Programming/ForgeMod Test Folder/";
            if (path == testDrive)
            {
                mainRegistry = path + "/MainRegistry.java";
                itemRegistry = path + "/ItemRegistry.java";
                blockRegistry = path + "/BlockRegistry.java";
            }
            else
            {
                mainRegistry = path + "/main/MainRegistry.java";
                itemRegistry = path + "/item/ItemRegistry.java";
                blockRegistry = path + "/block/BlockRegistry.java";
            }
            campPath = path;
        }

        public string DisplaySources(string[] src) {
            string[] source = new string[src.Length];
            int count = 0;
            foreach (string str in src)
            {
                if (Directory.Exists(str))
                {
                    source[count] = str;
                    mainWindow.AddSourceToList(str);
                    count++;
                }
            }
            string ret = (source[0] != null) ? source[0] : "No Source Detected";
            mainWindow.SetSelectedSource(ret);
            return ret;
        }

        public Boolean isRedundant(String myFile, String searchString) 
        {
            StreamReader sr = new StreamReader(myFile);

            String lineContents = "";
            lineContents = sr.ReadLine();
            while (sr.Peek() >= 0)
            {
                if (lineContents.Contains(searchString)){
				    sr.Close();
				    return true;
			    }
            lineContents = sr.ReadLine();
		    }
            sr.Close();
		    return false;
	    }

        public void addMaterial(String name, int harvestLevel, int durability, float harvestSpeed, float damage, int enchantability)
        {
            findFiles();
            String typeFile = mainRegistry;

            String decSearchString = "Material Declaration Space";
            String decInsertString = "	public static final Item.ToolMaterial " + name + " = EnumHelper.addToolMaterial(\"" + name + "\", " + harvestLevel + 
				", " + durability + ", " + harvestSpeed + ", " + damage + ", " + enchantability + ");";

            Object []
            temp = findInsertingSpace(typeFile, name, decSearchString, decInsertString, 0, "");
            String fileContent = (String)temp [0];

            int num = (int)temp[1];

            fileContent = finishRead(typeFile, num, fileContent);
		
		    if(isRedundant(typeFile, decInsertString)){
			    //System.out.println("Material Registration already exists, skipping Main Registry rewrite");
            }
		    else{
			    //System.out.println("Updating Main Registry...");
                //System.out.println("Opening file: " + typeFile.toString());

                writeFile(typeFile, fileContent);
            }
	    }

        public void addObject(String name, String category, String type, String material)
        {
            findFiles();
            String typeFile;
            String initInsertEnd;
            String nameSanitized = name.ToLower().Replace(" ", "").Replace("Sword", "").Replace("Block", "").Replace("Bow", "").Replace("sword", "").Replace("block", "").Replace("bow", "");

            if (material == " "){
                material = "WAFFLETOOL";
            }
		
		    if(type == "Block"){
                typeFile = blockRegistry;
                initInsertEnd = "(Material.rock);";
            }
		    else if(type == "Sword"){
                typeFile = itemRegistry;
                initInsertEnd = "(MainRegistry." + material + ");";
            }
		    else if(type == "Bow"){
                typeFile = itemRegistry;
                initInsertEnd = "();";
            }
		    else{
                typeFile = mainRegistry;
                initInsertEnd = "";
            }

            // Block Strings;
            String decSearchString = category + " Declaration Space";
            String decInsertString = "	public static " + category + " " + nameSanitized + type + ";";

            String initSearchString = category + " Initialization Space";
            String initInsertString = "		"+ nameSanitized + type + " = new " + name + type + initInsertEnd;

            String regSearchString = category + " Registration Space";
            String regInsertString = "		GameRegistry.register" + category + "(" + nameSanitized + type + ", " + nameSanitized + type + ".getUnlocalizedName());";
            Object[] temp;
            String fileContent = "";
            int num = 0;

            if (!isRedundant(typeFile, decInsertString))
            {
                temp = findInsertingSpace(typeFile, name, decSearchString, decInsertString, 0, "");
                fileContent = (String)temp[0];
                num = (int)temp[1];
            }

            if (!isRedundant(typeFile, initInsertString))
            {
                //System.out.println("Finding " + blockInitSearchString + "...");
                temp = findInsertingSpace(typeFile, name, initSearchString, initInsertString, num, fileContent);
                fileContent = (String)temp[0];
                num = (int)temp[1];
            }

            if (!isRedundant(typeFile, regInsertString))
            {
                //System.out.println("Finding " + blockRegSearchString + "...");
                temp = findInsertingSpace(typeFile, name, regSearchString, regInsertString, num, fileContent);
                fileContent = (String)temp[0];
                num = (int)temp[1];
            }
		
		    fileContent = finishRead(typeFile, num, fileContent);
		
		    if(isRedundant(typeFile, decInsertString) && isRedundant(typeFile, initInsertString) && isRedundant(typeFile, regInsertString)){
			    //System.out.println(category + " Registration already exists, skipping " + category + "Registry rewrite");
            }
		    else{
			    //System.out.println("Updating " + category + "Registry...");
                //System.out.println("Opening file: " + typeFile.toString());

                writeFile(typeFile, fileContent);
            }
            //System.out.println("Creating " + type + " Class file...");
		    if (type == "Block"){
                writeFile(campPath + "/" + category.ToLower() + "/" + nameSanitized + type + ".java", FlexModContent.createNewBlock(name, nameSanitized));
		    }
		    else if (type == "Sword"){
                writeFile(campPath + "/" + category.ToLower() + "/" + nameSanitized + type + ".java", FlexModContent.createNewSword(name, nameSanitized));
		    }
		    else if (type == "Bow"){
                writeFile(campPath + "/" + category.ToLower() + "/" + nameSanitized + type + ".java", FlexModContent.createNewBow(name, nameSanitized));
		    }
	    }

        public void writeFile(String myFile, String fileContent)
        {
            FileStream outFileStream = new FileStream(myFile, FileMode.Create, FileAccess.Write);

            Byte[] buffer = null;
            buffer = ASCIIEncoding.ASCII.GetBytes(fileContent);
            outFileStream.Write(buffer, 0, buffer.Length);
            outFileStream.Close();
        }
    }
}
