﻿using System;
using System.IO;
namespace Pk2ReaderAPI.Files
{
    /// <summary>
    /// Helper class having all necessary to handle SkillData files
    /// </summary>
    public static class SkillData
    {
        #region Column Names
        public const byte
            Service = 0,
            ID = 1,
            GroupID = 2,
            Basic_Code = 3,
            Basic_Name = 4,
            Basic_Group = 5,
            Basic_Original = 6,
            Basic_Level = 7,
            Basic_Activity = 8,
            Basic_ChainCode = 9,
            Basic_RecycleCost = 10,
            Action_PreparingTime = 11,
            Action_CastingTime = 12,
            Action_ActionDuration = 13,
            Action_ReuseDelay = 14,
            Action_CoolTime = 15,
            Action_FlyingSpeed = 16,
            Action_Interruptable = 17,
            Action_Overlap = 18,
            Action_AutoAttackType = 19,
            Action_InTown = 20,
            Action_Range = 21,
            Target_Required = 22,
            TargetType_Animal = 23,
            TargetType_Land = 24,
            TargetType_Building = 25,
            TargetGroup_Self = 26,
            TargetGroup_Ally = 27,
            TargetGroup_Party = 28,
            TargetGroup_Enemy_M = 29,
            TargetGroup_Enemy_P = 30,
            TargetGroup_Neutral = 31,
            TargetGroup_DontCare = 32,
            TargetEtc_SelectDeadBody = 33,
            ReqCommon_Mastery1 = 34,
            ReqCommon_Mastery2 = 35,
            ReqCommon_MasteryLevel1 = 36,
            ReqCommon_MasteryLevel2 = 37,
            ReqCommon_Str = 38,
            ReqCommon_Int = 39,
            ReqLearn_Skill1 = 40,
            ReqLearn_Skill2 = 41,
            ReqLearn_Skill3 = 42,
            ReqLearn_SkillLevel1 = 43,
            ReqLearn_SkillLevel2 = 44,
            ReqLearn_SkillLevel3 = 45,
            ReqLearn_SP = 46,
            ReqLearn_Race = 47,
            Req_Restriction1 = 48,
            Req_Restriction2 = 49,
            ReqCast_Weapon1 = 50,
            ReqCast_Weapon2 = 51,
            Consume_HP = 52,
            Consume_MP = 53,
            Consume_HPRatio = 54,
            Consume_MPRatio = 55,
            Consume_WHAN = 56,
            UI_SkillTab = 57,
            UI_SkillPage = 58,
            UI_SkillColumn = 59,
            UI_SkillRow = 60,
            UI_IconFile = 61,
            UI_SkillName = 62,
            UI_SkillToolTip = 63,
            UI_SkillToolTip_Desc = 64,
            UI_SkillStudy_Desc = 65,
            AI_AttackChance = 66,
            AI_SkillType = 67,
            Param1 = 68,
            Param2 = 69,
            Param3 = 70,
            Param4 = 71,
            Param5 = 72,
            Param6 = 73,
            Param7 = 74,
            Param8 = 75,
            Param9 = 76,
            Param10 = 77,
            Param11 = 78,
            Param12 = 79,
            Param13 = 80,
            Param14 = 81,
            Param15 = 82,
            Param16 = 83,
            Param17 = 84,
            Param18 = 85,
            Param19 = 86,
            Param20 = 87,
            Param21 = 88,
            Param22 = 89,
            Param23 = 90,
            Param24 = 91,
            Param25 = 92,
            Param26 = 93,
            Param27 = 94,
            Param28 = 95,
            Param29 = 96,
            Param30 = 97,
            Param31 = 98,
            Param32 = 99,
            Param33 = 100,
            Param34 = 101,
            Param35 = 102,
            Param36 = 103,
            Param37 = 104,
            Param38 = 105,
            Param39 = 106,
            Param40 = 107,
            Param41 = 108,
            Param42 = 109,
            Param43 = 110,
            Param44 = 111,
            Param45 = 112,
            Param46 = 113,
            Param47 = 114,
            Param48 = 115,
            Param49 = 116,
            Param50 = 117;
        #endregion

        #region Skill Params
        /// <summary>
        /// Skill parameters
        /// </summary>
        public enum ParamType : uint
        {
            /// <summary>
            /// <para>0. On casting</para>
            /// <para>1. Through time</para> 
            /// </summary>
            MP_CONSUME = 1869506150,
            /// <summary>
            /// <para>0. Duration (ms)</para> 
            /// </summary>
            SKILL_DURATION = 1685418593,
            /// <summary>
            /// <para>0. Damage type</para>
            /// <para>1. Damage % (Monsers)</para>
            /// <para>2. Min. Damage</para>
            /// <para>3. Max. Damage</para>
            /// <para>4. Damage % (Players)</para>
            /// </summary>
            SKILL_ATTACK = 6386804,
            /// <summary>
            /// <para>0. Absolute Damage (Ignore defense)</para> 
            /// </summary>
            ABSOLUTENESS_DAMAGE = 1885629799,
            /// <summary>
            /// <para>0. Weapon param (Ignore defense)</para> 
            /// </summary>
            WEAPON_ITEM_REQUIRED = 1685418593,
            /// <summary>
            /// Indicates if the skill can be overrided
            /// </summary>
            EFFECT_AUTO_TRANSFER = 1701213281
        }
        /// <summary>
        /// Return true if the param exists into the parameter list
        /// </summary>
        /// <param name="Params">The parameters to compare</param>
        /// <param name="Type">The param to found</param>
        public static bool Exists(string[] Params, ParamType Type)
        {
            string strType = ((uint)Type).ToString();
            for (byte i = 0; i < Params.Length; i++)
                if (Params[i] == strType)
                    return true;
            return false;
        }
        /// <summary>
        /// Read the argument value from the param type specified. 
        /// Returns an empty string if is not found into the list
        /// </summary>
        /// <param name="Params">Parameter list</param>
        /// <param name="Type">Param type to find</param>
        /// <param name="Position">Argument position</param>
        public static string ReadParamValue(string[] Params, ParamType Type, byte Position = 0)
        {
            string strType = ((uint)Type).ToString();
            Position++;

            for (byte i = 0; i < Params.Length; i++)
                if (Params[i] == strType)
                    return Params[i + Position];
            return string.Empty;
        }
        #endregion

        #region Cryptography
        /// <summary>
        /// Encrypts the file
        /// </summary>
        /// <param name="skillDataBuffer">The byte array which contains the skilldata.txt file</param>
        /// <returns>Returns the data encrypted</returns>
        public static byte[] Encrypt(byte[] skillDataBuffer)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Decrypts the file but only if is necessary
        /// </summary>
        /// <param name="skillDataBuffer">The byte array from SkillData files</param>
        /// <returns>Returns the data decrypted</returns>
        public static byte[] Decrypt(byte[] skillDataBuffer)
        {
             // Check if the data is correct and truly encoded
            if (skillDataBuffer != null && skillDataBuffer.Length >= 2 &&
                skillDataBuffer[0] == 0xE2 && skillDataBuffer[1] == 0xB0)
            {
                // define hash tables
                byte[] HashTable1 = new byte[]{
                    0x07, 0x83, 0xBC, 0xEE, 0x4B, 0x79, 0x19, 0xB6, 0x2A, 0x53, 0x4F, 0x3A, 0xCF, 0x71, 0xE5, 0x3C,
                    0x2D, 0x18, 0x14, 0xCB, 0xB6, 0xBC, 0xAA, 0x9A, 0x31, 0x42, 0x3A, 0x13, 0x42, 0xC9, 0x63, 0xFC,
                    0x54, 0x1D, 0xF2, 0xC1, 0x8A, 0xDD, 0x1C, 0xB3, 0x52, 0xEA, 0x9B, 0xD7, 0xC4, 0xBA, 0xF8, 0x12,
                    0x74, 0x92, 0x30, 0xC9, 0xD6, 0x56, 0x15, 0x52, 0x53, 0x60, 0x11, 0x33, 0xC5, 0x9D, 0x30, 0x9A,
                    0xE5, 0xD2, 0x93, 0x99, 0xEB, 0xCF, 0xAA, 0x79, 0xE3, 0x78, 0x6A, 0xB9, 0x02, 0xE0, 0xCE, 0x8E,
                    0xF3, 0x63, 0x5A, 0x73, 0x74, 0xF3, 0x72, 0xAA, 0x2C, 0x9F, 0xBB, 0x33, 0x91, 0xDE, 0x5F, 0x91,
                    0x66, 0x48, 0xD1, 0x7A, 0xFD, 0x3F, 0x91, 0x3E, 0x5D, 0x22, 0xEC, 0xEF, 0x7C, 0xA5, 0x43, 0xC0,
                    0x1D, 0x4F, 0x60, 0x7F, 0x0B, 0x4A, 0x4B, 0x2A, 0x43, 0x06, 0x46, 0x14, 0x45, 0xD0, 0xC5, 0x83,
                    0x92, 0xE4, 0x16, 0xD0, 0xA3, 0xA1, 0x13, 0xDA, 0xD1, 0x51, 0x07, 0xEB, 0x7D, 0xCE, 0xA5, 0xDB,
                    0x78, 0xE0, 0xC1, 0x0B, 0xE5, 0x8E, 0x1C, 0x7C, 0xB4, 0xDF, 0xED, 0xB8, 0x53, 0xBA, 0x2C, 0xB5,
                    0xBB, 0x56, 0xFB, 0x68, 0x95, 0x6E, 0x65, 0x00, 0x60, 0xBA, 0xE3, 0x00, 0x01, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x9C, 0xB5, 0xD5, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2E, 0x3F, 0x41, 0x56,
                    0x43, 0x45, 0x53, 0x63, 0x72, 0x69, 0x70, 0x74, 0x40, 0x40, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x64, 0xBB, 0xE3, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
                };
                byte[] HashTable2 = new byte[]{
                    0x0D, 0x05, 0x90, 0x41, 0xF9, 0xD0, 0x65, 0xBF, 0xF9, 0x0B, 0x15, 0x93, 0x80, 0xFB, 0x01, 0x02,
                    0xB6, 0x08, 0xC4, 0x3C, 0xC1, 0x49, 0x94, 0x4D, 0xCE, 0x1D, 0xFD, 0x69, 0xEA, 0x19, 0xC9, 0x57,
                    0x9C, 0x4D, 0x84, 0x62, 0xE3, 0x67, 0xF9, 0x87, 0xF4, 0xF9, 0x93, 0xDA, 0xE5, 0x15, 0xF1, 0x4C,
                    0xA4, 0xEC, 0xBC, 0xCF, 0xDD, 0xB3, 0x6F, 0x04, 0x3D, 0x70, 0x1C, 0x74, 0x21, 0x6B, 0x00, 0x71,
                    0x31, 0x7F, 0x54, 0xB3, 0x72, 0x6C, 0xAA, 0x42, 0xC1, 0x78, 0x61, 0x3E, 0xD5, 0xF2, 0xE1, 0x27,
                    0x36, 0x71, 0x3A, 0x25, 0x36, 0x57, 0xD1, 0xF8, 0x70, 0x86, 0xBD, 0x0E, 0x58, 0xB3, 0x76, 0x6D,
                    0xC3, 0x50, 0xF6, 0x6C, 0xA0, 0x10, 0x06, 0x64, 0xA2, 0xD6, 0x2C, 0xD4, 0x27, 0x30, 0xA5, 0x36,
                    0x1C, 0x1E, 0x3E, 0x58, 0x9D, 0x59, 0x76, 0x9D, 0xA7, 0x42, 0x5A, 0xF0, 0x00, 0xBC, 0x69, 0x31,
                    0x40, 0x1E, 0xFA, 0x09, 0x1D, 0xE7, 0xEE, 0xE4, 0x54, 0x89, 0x36, 0x7C, 0x67, 0xC8, 0x65, 0x22,
                    0x7E, 0xA3, 0x60, 0x44, 0x1E, 0xBC, 0x68, 0x6F, 0x15, 0x2A, 0xFD, 0x9D, 0x3F, 0x36, 0x6B, 0x28,
                    0x06, 0x67, 0xFE, 0xC6, 0x49, 0x6B, 0x9B, 0x3F, 0x80, 0x2A, 0xD2, 0xD4, 0xD3, 0x20, 0x1B, 0x96,
                    0xF4, 0xD2, 0xCA, 0x8C, 0x74, 0xEE, 0x0B, 0x6A, 0xE1, 0xE9, 0xC6, 0xD2, 0x6E, 0x33, 0x63, 0xC0,
                    0xE9, 0xD0, 0x37, 0xA9, 0x3C, 0xF7, 0x18, 0xF2, 0x4A, 0x74, 0xEC, 0x41, 0x61, 0x7A, 0x19, 0x47,
                    0x8F, 0xA0, 0xBB, 0x94, 0x8F, 0x3D, 0x11, 0x11, 0x26, 0xCF, 0x69, 0x18, 0x1B, 0x2C, 0x87, 0x6D,
                    0xB3, 0x22, 0x6C, 0x78, 0x41, 0xCC, 0xC2, 0x84, 0xC5, 0xCB, 0x01, 0x6A, 0x37, 0x00, 0x01, 0x65,
                    0x4F, 0xA7, 0x85, 0x85, 0x15, 0x59, 0x05, 0x67, 0xF2, 0x4F, 0xAB, 0xB7, 0x88, 0xFA, 0x69, 0x24,
                    0x9E, 0xC6, 0x7B, 0x3F, 0xD5, 0x0E, 0x4D, 0x7B, 0xFB, 0xB1, 0x21, 0x3C, 0xB0, 0xC0, 0xCB, 0x2C,
                    0xAA, 0x26, 0x8D, 0xCC, 0xDD, 0xDA, 0xC1, 0xF8, 0xCA, 0x7F, 0x6A, 0x3F, 0x2A, 0x61, 0xE7, 0x60,
                    0x5C, 0xCE, 0xD3, 0x4C, 0xAC, 0x45, 0x40, 0x62, 0xEA, 0x51, 0xF1, 0x66, 0x5D, 0x2C, 0x45, 0xD6,
                    0x8B, 0x7D, 0xCE, 0x9C, 0xF5, 0xBB, 0xF7, 0x52, 0x24, 0x1A, 0x13, 0x02, 0x2B, 0x00, 0xBB, 0xA1,
                    0x8F, 0x6E, 0x7A, 0x33, 0xAD, 0x5F, 0xF4, 0x4A, 0x82, 0x76, 0xAB, 0xDE, 0x80, 0x98, 0x8B, 0x26,
                    0x4F, 0x33, 0xD8, 0x68, 0x1E, 0xD9, 0xAE, 0x06, 0x6B, 0x7E, 0xA9, 0x95, 0x67, 0x60, 0xEB, 0xE8,
                    0xD0, 0x7D, 0x07, 0x4B, 0xF1, 0xAA, 0x9A, 0xC5, 0x29, 0x93, 0x9D, 0x5C, 0x92, 0x3F, 0x15, 0xDE,
                    0x48, 0xF1, 0xCA, 0xEA, 0xC9, 0x78, 0x3C, 0x28, 0x7E, 0xB0, 0x46, 0xD3, 0x71, 0x6C, 0xD7, 0xBD,
                    0x2C, 0xF7, 0x25, 0x2F, 0xC7, 0xDD, 0xB4, 0x6D, 0x35, 0xBB, 0xA7, 0xDA, 0x3E, 0x3D, 0xA7, 0xCA,
                    0xBD, 0x87, 0xDD, 0x9F, 0x22, 0x3D, 0x50, 0xD2, 0x30, 0xD5, 0x14, 0x5B, 0x8F, 0xF4, 0xAF, 0xAA,
                    0xA0, 0xFC, 0x17, 0x3D, 0x33, 0x10, 0x99, 0xDC, 0x76, 0xA9, 0x40, 0x1B, 0x64, 0x14, 0xDF, 0x35,
                    0x68, 0x66, 0x5B, 0x49, 0x05, 0x33, 0x68, 0x26, 0xC8, 0xBA, 0xD1, 0x8D, 0x39, 0x2B, 0xFB, 0x3E,
                    0x24, 0x52, 0x2F, 0x9A, 0x69, 0xBC, 0xF2, 0xB2, 0xAC, 0xB8, 0xEF, 0xA1, 0x17, 0x29, 0x2D, 0xEE,
                    0xF5, 0x23, 0x21, 0xEC, 0x81, 0xC7, 0x5B, 0xC0, 0x82, 0xCC, 0xD2, 0x91, 0x9D, 0x29, 0x93, 0x0C,
                    0x9D, 0x5D, 0x57, 0xAD, 0xD4, 0xC6, 0x40, 0x93, 0x8D, 0xE9, 0xD3, 0x35, 0x9D, 0xC6, 0xD3, 0x00
                };
                uint key = 0x8C1F;
                byte[] bufferDecoded = new byte[skillDataBuffer.Length];

                // Decoding
                byte buff;
                for (int i = 0; i < skillDataBuffer.Length; i++)
                {
                    buff = (byte)(HashTable1[key % 0xA7] - HashTable2[key % 0x1Ef]);
                    key++;
                    bufferDecoded[i] = (byte)(skillDataBuffer[i] + buff);
                }
                return bufferDecoded;
            }
            return skillDataBuffer;
        }
        #endregion
    }
}
