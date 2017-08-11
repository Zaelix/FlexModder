using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexModder
{
    class FlexModContent
    {
        static String eol = Environment.NewLine;

        public static String createNewSword(String name, String nameSanitized)
        {
            String newSword = "package com.camp.item;" + eol + "import net.minecraft.item.Item.ToolMaterial;" + eol +
                "import net.minecraft.item.ItemSword;" + eol + "import com.camp.lib.Strings;" + eol +
                "import com.camp.main.MainRegistry;" + eol + "import net.minecraft.creativetab.CreativeTabs;" + eol +
                "public class " + nameSanitized + "Sword extends ItemSword{" + eol + "	public " + nameSanitized + "Sword(ToolMaterial material){" + eol +
                "		super(material);" + eol + "		this.setUnlocalizedName(\"" + name + "\");" + eol +
                "		this.setCreativeTab(CreativeTabs.tabCombat);" + eol + "		this.setMaxStackSize(1);" + eol +
                "		this.setTextureName(Strings.MODID + \":\" + \"" + nameSanitized + "\");" + eol + "	}" + eol + "}";
            return newSword;
        }

        public static String createNewBlock(String name, String nameSanitized)
        {
            String newBlock = "package com.camp.block;" + eol + "import com.camp.lib.Strings;" + eol +
                    "import net.minecraft.block.Block;" + eol + "import net.minecraft.block.material.Material;" + eol +
                    "import net.minecraft.creativetab.CreativeTabs;" + eol + "public class " + nameSanitized + "Block extends Block{" + eol +
                    "	protected " + nameSanitized + "Block(Material p_i45394_1_){" + eol + "		super(p_i45394_1_);" + eol +
                    "		this.setBlockName(\"" + name + "\");" + eol + "		this.setCreativeTab(CreativeTabs.tabBlock);" + eol +
                    "		this.setBlockTextureName(Strings.MODID + \":\" + \"" + nameSanitized + "_block\");" + eol + "	}" + eol + "}";
            return newBlock;
        }

        public static String createNewBow(String name, String nameSanitized)
        {
            String newBow = "package com.camp.item;" + eol + eol + "import com.camp.lib.Strings;" + eol +
                    "import cpw.mods.fml.relauncher.Side;" + eol + "import cpw.mods.fml.relauncher.SideOnly;" + eol +
                    "import net.minecraft.client.renderer.texture.IIconRegister;" + eol +
                    "import net.minecraft.creativetab.CreativeTabs;" + eol +
                    "import net.minecraft.entity.player.EntityPlayer;" + eol + "import net.minecraft.item.ItemBow;" + eol +
                    "import net.minecraft.item.ItemStack;" + eol + "import net.minecraft.util.IIcon;" + eol + eol +
                    "public class " + nameSanitized + "Bow extends ItemBow{" + eol +
                    "public static final String[] iconNameArray = new String[] {\"pulling_0\", \"pulling_1\", \"pulling_2\"};" + eol +
                    "   @SideOnly(Side.CLIENT)" + eol + "	private IIcon[] iconArray;" + eol +
                    "    private static final String iconString = \"" + nameSanitized + "Bow\";" + eol + eol + "    public " + nameSanitized + "Bow()" + eol +
                    "	{" + eol + "    	this.setUnlocalizedName(\"" + name + "\");" + eol +
                    "        this.maxStackSize = 1;" + eol + "        this.setMaxDamage(3840);" + eol +
                    "        this.setCreativeTab(CreativeTabs.tabCombat);" + eol + "    }" + eol + eol +
                    "    @SideOnly(Side.CLIENT)" + eol + "    public void registerIcons(IIconRegister icon)" + eol +
                    "    {" + eol + "        this.itemIcon = icon.registerIcon(Strings.MODID + \":\" + \"" + nameSanitized + "Bow\" + \"_standby\");" + eol +
                    "        this.iconArray = new IIcon[iconNameArray.length];" + eol +
                    "        for (int i = 0; i < this.iconArray.length; ++i)" + eol + "        {" + eol +
                    "            this.iconArray[i] = icon.registerIcon(Strings.MODID + \":\" + \"" + nameSanitized + "Bow\" + \"_\" + iconNameArray[i]);" + eol +
                    "        }" + eol + "    }" + eol + eol + "    @Override" + eol + "    @SideOnly(Side.CLIENT)" + eol +
                    "    public IIcon getIcon(ItemStack stack, int renderPass, EntityPlayer player, ItemStack usingItem, int useRemaining) {" + eol +
                    "        if (usingItem == null) { return itemIcon; }" + eol + "        int ticksInUse = stack.getMaxItemUseDuration() - useRemaining;" + eol +
                    "        if (ticksInUse > 18) {" + eol + "              return iconArray[2];" + eol + "        } else if (ticksInUse > 14) {" + eol +
                    "            return iconArray[1];" + eol + "        } else if (ticksInUse > 0) {" + eol + "            return iconArray[0];" + eol +
                    "        } else {" + eol + "            return itemIcon;" + eol + "        }" + eol + "    }" + eol + "};";
            return newBow;
        }
        
    }
}
