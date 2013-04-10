using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Utau.Eramakerview.GameData
{
    internal enum CharacterStrData
    {
        NAME = 0,
        CALLNAME = 1,
        NICKNAME = 2,
        MASTERNAME = 3,
        CSTR = 4,
    }

    internal enum CharacterIntData
    {
        BASE = 0,
        ABL = 1,
        TALET = 2,
        MARK = 3,
        EXP = 4,
        RELATION = 5,
        CFLAG = 6,
        EQUIP = 7,
        JUEL = 8,
    }

    
    /*
     * 次はVariablesizeの読み込み
     * →読み込み用機能
     * →StreamReader
     * →Ablなどの読み込みも考えた設計
     * →設計図
     */
    public class ConstantData
    {
        //loadVariableDataでVariableSize.csv読み込み
        //LimitSize
        //PalamIntArray[ABL](いらない？)
        //PalamStrArray[ABL][35]
        //if Range(範囲)

        //CharaIntData[キャラ番号][ABL][85]
        //CharaStrData[キャラ番号][NAME]

        //キャラクターの数
        private CharacterTemplate[] chara = new CharacterTemplate[9999];
        //CharacterTemplate charaData = new CharacterTemplate();
        
        //loadDataでcharaにデータを格納
        CharacterTemplate charaData = new CharacterTemplate();
        //chara[0] = charaData;

        /*
         * charaData[x]+=loadData(Abl,x)
         * or
         * 
         * 
         * for i=0,i<99;i++
         * ReadLineで一列ずつ読む
         * token[0][1][2]   ->  [能力,親密,1 or ABL,0,1]
         *  switch token[0]
         *      case "TALENT":
         *      case "素質":
         *          a=token[1]
         *          if ToInt(a) != -1 ?
         *             talent[a]=token[2]
         *          else
         *             a=ToIntTalent(a)
         *             talent[a]=token[2]
         *             
         * token[2]->
         *          
         */

        private void loadVariableSizeData(string csvpath)
        {
            if (!File.Exists(csvpath))
                return;
            /*
             * csvからsize読む(loadVariableSizeData)
             * size名が既定の変数名と違えばエラーorスルー
             * elseSize保存(Code?int?)
             * 
             * sizeでフィルタを掛け、Ablなどcsvを読み込む(loadCsvData)
             * 変数の名前を保存する
             * string ablname[]="Ｃ感覚"的な
             * 
             * chara型配列を宣言  Chara[]
             * chara.toCharacterData(Chara chara, string tokens[])
             *  charadata読み込み(loadCharaData)
             *  chara[abl][0]=1等でデータ作る
             *  
             */
        }
    }

    public class CharacterTemplate
    {
        public string NAME;
        public string CALLNAME;

        //配列はインデクサーかプロパティを使い、フェイルソフトに
        public int NO;
        public int[] BASE;
        public int[] TALENT;
        public int[] ABL;
        public int[] EXP;
        public int[] RELATION;
        public int[] CFLAG;

        //LENGTH
        //typeはenumでintにした方が綺麗？
        public void ADD(string type ,int no,int data)
        {
            switch (type)
            {
                case "TALENT":
                    TALENT[no] = data;
                    break;

                    
            }
        }
    }

    //フェイルソフトな配列
    //variableSizeでフィルタを掛ける
    public class FailSoftArray
    {
        public FailSoftArray() { }

        int[] a;

        public int this[int index]
        {
            get
            {
                return a[index];
            }

            set
            {
                a[index] = value;
            }
        }
    }

}
