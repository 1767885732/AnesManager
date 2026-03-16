using System;
using System.Collections.Generic;
using System.Text;

namespace Wis.Anes.DataAccess
{
    public partial class OracleScriptProvider
    {
        public string Score_GetPatientScoringResultDataByPatientInfoAndMethod
        {
            get
            {
                return
                    @"SELECT     PAT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, SCORING_METHOD, SCORING_VALUE,
                    DEGREE, DEATH_PROBABILITY, PAT_CONDITION, 
                    WARD_CODE, OPERATOR, MEMO, ENTER_DATE_TIME, DEATH_RATE, ISS_SCORE, TRS_SCORE
                    FROM         WIS_PAT_SCORING_RESULT
                    WHERE     (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) AND (SCORING_METHOD = :method)
                    ORDER BY PAT_ID, VISIT_ID, SCORING_METHOD, SCORING_DATE_TIME";
            }
        }

        public string Score_GetMedRamsayScoredDataByPatientInfo
        {
            get
            {
                return
                    @"SELECT PAT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, SCORE, MEMO
                    FROM MED_RAMSAYSCORE where (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedRamsayScoredDataByPatientInfoAndDateTime
        {
            get
            {
                return
                    @"SELECT PAT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, SCORE, MEMO
                    FROM MED_RAMSAYSCORE 
                    where  (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) and SCORING_DATE_TIME=:dateTime";
            }
        }

        public string Score_GetApache2ScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return
                    @"  SELECT * FROM  WIS_SCORE_APACHE2_RESULT
                    where  (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) and SCORING_DATE_TIME=:dateTime";
            }
        }

        public string Score_GetApache2ScoringResultDetailByPatientInfo
        {
            get
            {
                return
                    @" SELECT * FROM WIS_SCORE_APACHE2_RESULT 
                    WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetSaps2ScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return
                    @"  SELECT * FROM MED_SAPS2_SCORING_RESULT
                     WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                    ( SCORING_DATE_TIME = :dateTime) ";
            }
        }

        public string Score_GetSaps2ScoringResultDetailByPatientInfo
        {
            get
            {
                return
                    @"  SELECT * FROM MED_SAPS2_SCORING_RESULT
                     WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetModsScoringResultDetalByPatientInfoAndDateTime
        {
            get
            {
                return @" SELECT * FROM med_mods_scoring_result_detail 
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                    ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetModsScoringResultDetalByPatientInfo
        {
            get
            {
                return @"SELECT BBIL, CR, EYES_REFLECT, FIO2, HR, LIMB_REFLECT, MAP, MEMO, PAO2, PAT_ID, PLT, RAP, 
                SCORING_DATE_TIME, TALK_REFLECT, VISIT_ID FROM MED_MODS_SCORING_RESULT_DETAIL 
                 WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) ";
            }
        }

        public string Score_GetMods2ScoringDetalByPatientInfoAndDateTime
        {
            get
            {
                return @" SELECT * FROM med_mods2_scoring_detail 
                  WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                    ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMods2ScoringDetalByPatientInfo
        {
            get
            {
                return @" SELECT * FROM med_mods2_scoring_detail 
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) ";
            }
        }

        public string Score_GetTissScoringResultDetalByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT * FROM WIS_SCORE_TISS_RESULT
               WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                    ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetTissScoringResultDetalByPatientInfo
        {
            get
            {
                return @" SELECT * FROM WIS_SCORE_TISS_RESULT
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)  ";
            }
        }

        public string Score_GetMedSsssScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PAT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S41, S42, S43, S5, S6, 
                S7, S8, S9, S10, S11, S12, S13, S14, MEMO
                FROM MED_SSSS_SCORING_RESULT_DETAIL
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedSsssScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PAT_ID,DEP_ID, S1, S10, S11, S12, S13, S14, S2, S3, S41, S42, S43, S5, S6, S7, S8, S9, 
                SCORING_DATE_TIME, VISIT_ID FROM MED_SSSS_SCORING_RESULT_DETAIL 
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedNortScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PAT_ID, VISIT_ID, SCORING_DATE_TIME, MEMO, S9, S8, S6, S7, S5, S4, S3, S2, S1
                FROM         MED_NORT_SCORING_RESULT_DETAIL
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedNortScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID
                FROM MED_NORT_SCORING_RESULT_DETAIL
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetSssScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, MEMO
                FROM MED_SSS_SCORING_RESULT_DETAIL
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetSssScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, S6, S7, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_SSS_SCORING_RESULT_DETAIL 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedSofaScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, EYES_REFLECT, 
                TALK_REFLECT, LIMB_REFLECT, MEMO
                FROM         MED_SOFA_SCORING_RESULT_DETAIL
                 WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedSofaScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT EYES_REFLECT, LIMB_REFLECT, MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, SCORING_DATE_TIME, TALK_REFLECT,
                VISIT_ID FROM MED_SOFA_SCORING_RESULT_DETAIL 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedCsssScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S41, S42, S43, S5, S6, S7, S8, S9, S10, S11, S12, 
                            S13, S14, S151, S152, S153, S154, S155, 
                            S161, S162, S163, MEMO
                            FROM         MED_CSSS_SCORING_RESULT_DETAIL
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedCsssScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S10, S11, S12, S13, S14, S151, S152, S153, S154, S155, S161, S162, S163, S2, S3, S41, S42, 
                S43, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID FROM
                MED_CSSS_SCORING_RESULT_DETAIL 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedCribScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, MEMO
                            FROM         MED_CRIB_SCORING_RESULT_DETAIL
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedCribScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, SCORING_DATE_TIME, VISIT_ID FROM MED_CRIB_SCORING_RESULT_DETAIL
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedApgarScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT * FROM MED_APGAR_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedApgarScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, SCORING_DATE_TIME, VISIT_ID FROM MED_APGAR_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedCramsScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, CIRCLE_STATUS,
                            BREATH_STATUS, BREAST_STATUS, LIMB_STATUS, TALK_STATUS, MEMO
                            FROM         MED_CRAMS_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedCramsScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT BREAST_STATUS, BREATH_STATUS, CIRCLE_STATUS, LIMB_STATUS, MEMO, PATIENT_ID, 
                SCORING_DATE_TIME, TALK_STATUS, VISIT_ID FROM MED_CRAMS_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedGpScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S2, S1, S3, S4, S5, S6, S7, MEMO
                            FROM         MED_GP_SCORING_RESULT_DETAIL
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedGpScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, S6, S7, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_GP_SCORING_RESULT_DETAIL 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedCgScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, MEMO
                            FROM         MED_CG_SCORING_RESULT_DETAIL
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedCgScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, SCORING_DATE_TIME, VISIT_ID FROM MED_CG_SCORING_RESULT_DETAIL
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedGcsScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, EYES_REFLECT, TALK_REFLECT, LIMB_REFLECT, MEMO
                            FROM         MED_GCS_SCORING_RESULT_DETAIL
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedGcsScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT EYES_REFLECT, LIMB_REFLECT, MEMO, PATIENT_ID, SCORING_DATE_TIME, TALK_REFLECT, VISIT_ID 
                FROM MED_GCS_SCORING_RESULT_DETAIL 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedLutzScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
                            S10, S11, S12, S13, S14, S15, MEMO
                            FROM MED_LUTZ_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedLutzScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S10, S11, S12, S13, S14, S15, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_LUTZ_SCORING_RESULT 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedBalthazarScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, MEMO
                            FROM MED_BALTHAZAR_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedBalthazarScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID, DEP_ID, S1, S2, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_BALTHAZAR_SCORING_RESULT 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedChildpughScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, MEMO
                            FROM MED_CHILDPUGH_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedChildpughScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, S6, S7, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_CHILDPUGH_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedParsScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PAT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, MEMO
                            FROM WIS_SCORE_PARS_RESULT
                            WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedParsScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PAT_ID,DEP_ID, S1, S2, S3, S4, S5, SCORING_DATE_TIME, VISIT_ID FROM WIS_SCORE_PARS_RESULT 
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedJohnsScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8,  MEMO
                            FROM MED_JOHNS_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedJohnsScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, MEMO
                FROM MED_JOHNS_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedGoldmanScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME,DEP_ID, S1, S3, S4, S5, S6, S7, S8, S9, MEMO, S2
                            FROM MED_GOLDMAN_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedGoldmanScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID, DEP_ID
                FROM MED_GOLDMAN_SCORING_RESULT 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedCribScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, DEP_ID,SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, MEMO
                            FROM MED_CRIB_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedCribScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S2, S3, S4, S5, S6, SCORING_DATE_TIME, VISIT_ID FROM MED_CRIB_SCORING_RESULT 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedIssTrsTrissScoringByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, SCORING_DATE_TIME, VISIT_ID, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, MEMO
                            FROM MED_ISS_TRS_TRISS_SCORING
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedIssTrsTrissScoringByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S10, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_ISS_TRS_TRISS_SCORING 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedPelodScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
                            S10, S11, S12, MEMO
                            FROM MED_PELOD_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedPelodScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, MEMO
                FROM MED_PELOD_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedMpmScoringByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT VISIT_ID, SCORING_DATE_TIME, PATIENT_ID, S1, S2, S3, S4, S5, S6, S7, S8, S10, 
                            S9, S11, S12, S13, S14, MEMO
                            FROM MED_MPM_SCORING
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedMpmScoringByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S10, S11, S12, S13, S14, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_MPM_SCORING
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedIcutraumaByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S9, S8, MEMO, S10
                            FROM MED_ICUTRAUMA
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedIcutraumaByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S10, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID FROM MED_ICUTRAUMA 
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedTiss28ScoringByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT * FROM MED_TISS28_SCORING
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedTiss28ScoringByPatientInfo
        {
            get
            {
                return
                @"SELECT NURSE_TIME, PATIENT_ID, S1, S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S2, S20, S21, S22, S23, S24, S3, S4,
                S5, S6, S7, S8, S9, SCORING_DATE_TIME, TISS_76, VISIT_ID 
                FROM MED_TISS28_SCORING
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedEuroScoringByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT * FROM MED_EURO_SCORING
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedEuroScoringByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, S1, S10, S11, S12, S13, S14, S15, S16, S17, S2, S3, S4, S5, S6, S7, S8, S9, 
                SCORING_DATE_TIME, VISIT_ID FROM MED_EURO_SCORING
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedNtissScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
                            S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S20, S21, S22, S23, S24, S25, S26, 
                            S27, S28, S29, S30, S31, S32, S33, S34, S35, S36, S37, S38, S39, S40, S41, S42, S43, 
                            S44, S45, S46, S47, S48, MEMO
                            FROM MED_NTISS_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedNtissScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT MEMO, PATIENT_ID,DEP_ID, S1, S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S2, 
                S20, S21, S22, S23, S24, S25, S26, S27, S28, S29,
                S3, S30, S31, S32, S33, S34, S35, S36, S37, S38, S39, S4, S40, S41, S42, 
                S43, S44, S45, S46, S47, S48, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
                FROM MED_NTISS_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedBabyscoreScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
                            S10, S11, STYPE, MEMO
                            FROM MED_BABYSCORE_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedBabyscoreScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
                S10, S11, STYPE, MEMO
                FROM MED_BABYSCORE_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedPrismScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
                            S10, S11, S12, S13, S14, S15, S16, MEMO
                            FROM MED_PRISM_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedPrismScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
                S10, S11, S12, S13, S14, S15, S16, MEMO
                FROM MED_PRISM_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedMedsScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, MEMO
                            FROM MED_MEDS_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedMedsScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, MEMO
                FROM MED_MEDS_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedApaScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PAT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, RECTAL_TEMP, MEANA_RTERIAL_P, 
                            HEART_RATE, RESPIRATORY, OXYGENATION, ARTERIAL_BLOOD, SERUM_SODIUM, 
                            SERUM_POTAS, SERUM_CREATININE, BLOOD_CELLSTH, BLOOD_CELLCO, GLASGOW, 
                            HCO3, AGEFACTOR_SCORE, MEMO, CHRONIC_LIVER, CHRONIC_CARD, CHRONIC_RESP, 
                            CHRONIC_RENAL, CHRONIC_IMMUNE
                            FROM WIS_SCORE_APA_RESULT
                            WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedApaScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT PAT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, RECTAL_TEMP, MEANA_RTERIAL_P, 
                HEART_RATE, RESPIRATORY, OXYGENATION, ARTERIAL_BLOOD, SERUM_SODIUM, 
                SERUM_POTAS, SERUM_CREATININE, BLOOD_CELLSTH, BLOOD_CELLCO, GLASGOW, 
                HCO3, AGEFACTOR_SCORE, MEMO, CHRONIC_LIVER, CHRONIC_CARD, CHRONIC_RESP, 
                CHRONIC_RENAL, CHRONIC_IMMUNE
                FROM WIS_SCORE_APA_RESULT
                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedPreScoringResultDetailByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, PERCEPTION, WET, ACTIVITIES, 
                            MOVE, NUTRITION, FRICTION, MEMO
                            FROM MED_PRE_SCORING_RESULT_DETAIL
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedPreScoringResultDetailByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, PERCEPTION, WET, ACTIVITIES, 
                MOVE, NUTRITION, FRICTION, MEMO
                FROM MED_PRE_SCORING_RESULT_DETAIL
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedCpisScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, SECRETIONS, BREAST, FEVER, 
                            PERIPHERAL, PAO2, BACTERIAL, MEMO
                            FROM MED_CPIS_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedCpisScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT BACTERIAL, BREAST, FEVER, MEMO, PAO2, PATIENT_ID, PERIPHERAL, SCORING_DATE_TIME, SECRETIONS,
                VISIT_ID FROM MED_CPIS_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedRtsScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, GCS, SBP, R, RESERVED01, 
                            RESERVED02, RESERVED03, MEMO
                            FROM MED_RTS_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedRtsScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, GCS, SBP, R, RESERVED01, 
                RESERVED02, RESERVED03, MEMO
                FROM MED_RTS_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }

        public string Score_GetMedSirsSScoringResultByPatientInfoAndDateTime
        {
            get
            {
                return @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, TEMPERATURE, HEART_RATE, 
                            BREATH_FREQUENCY, WBC, RESERVED01, RESERVED02, RESERVED03, MEMO
                            FROM MED_SIRS_S_SCORING_RESULT
                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
                            ( SCORING_DATE_TIME = :dateTime)";
            }
        }

        public string Score_GetMedSirsSScoringResultByPatientInfo
        {
            get
            {
                return
                @"SELECT PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, TEMPERATURE, HEART_RATE, 
                BREATH_FREQUENCY, WBC, RESERVED01, RESERVED02, RESERVED03, MEMO
                FROM MED_SIRS_S_SCORING_RESULT
                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
            }
        }
    }


    //    public partial class OracleScriptProvider
    //    {
    //        public string Score_GetPatientScoringResultDataByPatientInfoAndMethod
    //        {
    //            get
    //            {
    //                return
    //                    @"SELECT     PAT_ID, VISIT_ID, SCORING_DATE_TIME, SCORING_METHOD, SCORING_VALUE,
    //                    DEGREE, DEATH_PROBABILITY, PAT_CONDITION, 
    //                    WARD_CODE, OPERATOR, MEMO, ENTER_DATE_TIME, DEATH_RATE, ISS_SCORE, TRS_SCORE
    //                    FROM         WIS_PAT_SCORING_RESULT
    //                    WHERE     (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) AND (SCORING_METHOD = :method)
    //                    ORDER BY PATIENT_ID, VISIT_ID, SCORING_METHOD, SCORING_DATE_TIME";
    //            }
    //        }

    //        public string Score_GetMedRamsayScoredDataByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                    @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, SCORE, MEMO
    //                    FROM MED_RAMSAYSCORE where (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedRamsayScoredDataByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return
    //                    @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, SCORE, MEMO
    //                    FROM MED_RAMSAYSCORE 
    //                    where  (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) and SCORING_DATE_TIME=:dateTime";
    //            }
    //        }

    //        public string Score_GetApache2ScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return
    //                    @"  SELECT * FROM  WIS_SCORE_APACHE2_RESULT
    //                    where  (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) and SCORING_DATE_TIME=:dateTime";
    //            }
    //        }

    //        public string Score_GetApache2ScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                    @" SELECT * FROM WIS_SCORE_APACHE2_RESULT 
    //                    WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetSaps2ScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return
    //                    @"  SELECT * FROM MED_SAPS2_SCORING_RESULT
    //                     WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                    ( SCORING_DATE_TIME = :dateTime) ";
    //            }
    //        }

    //        public string Score_GetSaps2ScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                    @"  SELECT * FROM MED_SAPS2_SCORING_RESULT
    //                     WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetModsScoringResultDetalByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @" SELECT * FROM med_mods_scoring_result_detail 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                    ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetModsScoringResultDetalByPatientInfo
    //        {
    //            get
    //            {
    //                return @"SELECT BBIL, CR, EYES_REFLECT, FIO2, HR, LIMB_REFLECT, MAP, MEMO, PAO2, PATIENT_ID, PLT, RAP, 
    //                SCORING_DATE_TIME, TALK_REFLECT, VISIT_ID FROM MED_MODS_SCORING_RESULT_DETAIL 
    //                 WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) ";
    //            }
    //        }

    //        public string Score_GetMods2ScoringDetalByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @" SELECT * FROM med_mods2_scoring_detail 
    //                  WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                    ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMods2ScoringDetalByPatientInfo
    //        {
    //            get
    //            {
    //                return @" SELECT * FROM med_mods2_scoring_detail 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID) ";
    //            }
    //        }

    //        public string Score_GetTissScoringResultDetalByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT * FROM WIS_SCORE_TISS_RESULT
    //               WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                    ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetTissScoringResultDetalByPatientInfo
    //        {
    //            get
    //            {
    //                return @" SELECT * FROM WIS_SCORE_TISS_RESULT
    //                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)  ";
    //            }
    //        }

    //        public string Score_GetMedSsssScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S41, S42, S43, S5, S6, 
    //                S7, S8, S9, S10, S11, S12, S13, S14, MEMO
    //                FROM MED_SSSS_SCORING_RESULT_DETAIL
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedSsssScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S10, S11, S12, S13, S14, S2, S3, S41, S42, S43, S5, S6, S7, S8, S9, 
    //                SCORING_DATE_TIME, VISIT_ID FROM MED_SSSS_SCORING_RESULT_DETAIL 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedNortScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, MEMO, S9, S8, S6, S7, S5, S4, S3, S2, S1
    //                FROM         MED_NORT_SCORING_RESULT_DETAIL
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedNortScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID
    //                FROM MED_NORT_SCORING_RESULT_DETAIL
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetSssScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, MEMO
    //                FROM MED_SSS_SCORING_RESULT_DETAIL
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetSssScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, S7, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_SSS_SCORING_RESULT_DETAIL 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedSofaScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, EYES_REFLECT, 
    //                TALK_REFLECT, LIMB_REFLECT, MEMO
    //                FROM         MED_SOFA_SCORING_RESULT_DETAIL
    //                 WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedSofaScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT EYES_REFLECT, LIMB_REFLECT, MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, SCORING_DATE_TIME, TALK_REFLECT,
    //                VISIT_ID FROM MED_SOFA_SCORING_RESULT_DETAIL 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedCsssScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S41, S42, S43, S5, S6, S7, S8, S9, S10, S11, S12, 
    //                            S13, S14, S151, S152, S153, S154, S155, 
    //                            S161, S162, S163, MEMO
    //                            FROM         MED_CSSS_SCORING_RESULT_DETAIL
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedCsssScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S10, S11, S12, S13, S14, S151, S152, S153, S154, S155, S161, S162, S163, S2, S3, S41, S42, 
    //                S43, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID FROM
    //                MED_CSSS_SCORING_RESULT_DETAIL 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedCribScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, MEMO
    //                            FROM         MED_CRIB_SCORING_RESULT_DETAIL
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedCribScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, SCORING_DATE_TIME, VISIT_ID FROM MED_CRIB_SCORING_RESULT_DETAIL
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedApgarScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT * FROM MED_APGAR_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedApgarScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, SCORING_DATE_TIME, VISIT_ID FROM MED_APGAR_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedCramsScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, CIRCLE_STATUS,
    //                            BREATH_STATUS, BREAST_STATUS, LIMB_STATUS, TALK_STATUS, MEMO
    //                            FROM         MED_CRAMS_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedCramsScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT BREAST_STATUS, BREATH_STATUS, CIRCLE_STATUS, LIMB_STATUS, MEMO, PATIENT_ID, 
    //                SCORING_DATE_TIME, TALK_STATUS, VISIT_ID FROM MED_CRAMS_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedGpScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S2, S1, S3, S4, S5, S6, S7, MEMO
    //                            FROM         MED_GP_SCORING_RESULT_DETAIL
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedGpScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, S7, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_GP_SCORING_RESULT_DETAIL 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedCgScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, MEMO
    //                            FROM         MED_CG_SCORING_RESULT_DETAIL
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedCgScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, SCORING_DATE_TIME, VISIT_ID FROM MED_CG_SCORING_RESULT_DETAIL
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedGcsScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT     PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, EYES_REFLECT, TALK_REFLECT, LIMB_REFLECT, MEMO
    //                            FROM         MED_GCS_SCORING_RESULT_DETAIL
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedGcsScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT EYES_REFLECT, LIMB_REFLECT, MEMO, PATIENT_ID, SCORING_DATE_TIME, TALK_REFLECT, VISIT_ID 
    //                FROM MED_GCS_SCORING_RESULT_DETAIL 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedLutzScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                            S10, S11, S12, S13, S14, S15, MEMO
    //                            FROM MED_LUTZ_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedLutzScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S10, S11, S12, S13, S14, S15, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_LUTZ_SCORING_RESULT 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedBalthazarScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, MEMO
    //                            FROM MED_BALTHAZAR_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedBalthazarScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_BALTHAZAR_SCORING_RESULT 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedChildpughScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, MEMO
    //                            FROM MED_CHILDPUGH_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedChildpughScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, S7, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_CHILDPUGH_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedParsScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PAT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, MEMO
    //                            FROM WIS_SCORE_PARS_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedParsScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PAT_ID, S1, S2, S3, S4, S5, SCORING_DATE_TIME, VISIT_ID FROM WIS_SCORE_PARS_RESULT 
    //                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedJohnsScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8,  MEMO
    //                            FROM MED_JOHNS_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedJohnsScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, MEMO
    //                FROM MED_JOHNS_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedGoldmanScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S3, S4, S5, S6, S7, S8, S9, MEMO, S2
    //                            FROM MED_GOLDMAN_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedGoldmanScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID
    //                FROM MED_GOLDMAN_SCORING_RESULT 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedCribScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, MEMO
    //                            FROM MED_CRIB_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedCribScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S2, S3, S4, S5, S6, SCORING_DATE_TIME, VISIT_ID FROM MED_CRIB_SCORING_RESULT 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedIssTrsTrissScoringByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, SCORING_DATE_TIME, VISIT_ID, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, MEMO
    //                            FROM MED_ISS_TRS_TRISS_SCORING
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedIssTrsTrissScoringByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S10, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_ISS_TRS_TRISS_SCORING 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedPelodScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                            S10, S11, S12, MEMO
    //                            FROM MED_PELOD_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedPelodScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, MEMO
    //                FROM MED_PELOD_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedMpmScoringByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT VISIT_ID, SCORING_DATE_TIME, PATIENT_ID, S1, S2, S3, S4, S5, S6, S7, S8, S10, 
    //                            S9, S11, S12, S13, S14, MEMO
    //                            FROM MED_MPM_SCORING
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedMpmScoringByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S10, S11, S12, S13, S14, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_MPM_SCORING
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedIcutraumaByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S9, S8, MEMO, S10
    //                            FROM MED_ICUTRAUMA
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedIcutraumaByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S10, S2, S3, S4, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID FROM MED_ICUTRAUMA 
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedTiss28ScoringByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT * FROM MED_TISS28_SCORING
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedTiss28ScoringByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT NURSE_TIME, PATIENT_ID, S1, S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S2, S20, S21, S22, S23, S24, S3, S4,
    //                S5, S6, S7, S8, S9, SCORING_DATE_TIME, TISS_76, VISIT_ID 
    //                FROM MED_TISS28_SCORING
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedEuroScoringByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT * FROM MED_EURO_SCORING
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedEuroScoringByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, S1, S10, S11, S12, S13, S14, S15, S16, S17, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                SCORING_DATE_TIME, VISIT_ID FROM MED_EURO_SCORING
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedNtissScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                            S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S20, S21, S22, S23, S24, S25, S26, 
    //                            S27, S28, S29, S30, S31, S32, S33, S34, S35, S36, S37, S38, S39, S40, S41, S42, S43, 
    //                            S44, S45, S46, S47, S48, MEMO
    //                            FROM MED_NTISS_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedNtissScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT MEMO, PATIENT_ID, S1, S10, S11, S12, S13, S14, S15, S16, S17, S18, S19, S2, 
    //                S20, S21, S22, S23, S24, S25, S26, S27, S28, S29,
    //                S3, S30, S31, S32, S33, S34, S35, S36, S37, S38, S39, S4, S40, S41, S42, 
    //                S43, S44, S45, S46, S47, S48, S5, S6, S7, S8, S9, SCORING_DATE_TIME, VISIT_ID 
    //                FROM MED_NTISS_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedBabyscoreScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                            S10, S11, STYPE, MEMO
    //                            FROM MED_BABYSCORE_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedBabyscoreScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                S10, S11, STYPE, MEMO
    //                FROM MED_BABYSCORE_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedPrismScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                            S10, S11, S12, S13, S14, S15, S16, MEMO
    //                            FROM MED_PRISM_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedPrismScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, 
    //                S10, S11, S12, S13, S14, S15, S16, MEMO
    //                FROM MED_PRISM_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedMedsScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, MEMO
    //                            FROM MED_MEDS_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedMedsScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, S1, S2, S3, S4, S5, S6, S7, S8, S9, MEMO
    //                FROM MED_MEDS_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedApaScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PAT_ID, VISIT_ID, SCORING_DATE_TIME, RECTAL_TEMP, MEAN_ARTERIAL_P, 
    //                            HEARTRATE, RESPIRATORY, OXYGENATION, ARTERIAL_BLOOD, SERUM_SODIUM, 
    //                            SERUM_POTAS, SERUM_CREATININE, BLOOD_CELLSTH, BLOOD_CELLCO, GLASGOW, 
    //                            HCO3, AGEFACTOR_SCORE, MEMO, CHRONIC_LIVER, CHRONIC_CARD, CHRONIC_RESP, 
    //                            CHRONIC_RENAL, CHRONIC_IMMUNE
    //                            FROM WIS_SCORE_APA_RESULT
    //                            WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedApaScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PAT_ID, VISIT_ID, SCORING_DATE_TIME, RECTAL_TEMP, MEAN_ARTERIAL_P, 
    //                HEART_RATE, RESPIRATORY, OXYGENATION, ARTERIAL_BLOOD, SERUM_SODIUM, 
    //                SERUM_POTAS, SERUM_CREATININE, BLOOD_CELLSTH, BLOOD_CELLCO, GLASGOW, 
    //                HCO3, AGEFACTOR_SCORE, MEMO, CHRONIC_LIVER, CHRONIC_CARD, CHRONIC_RESP, 
    //                CHRONIC_RENAL, CHRONIC_IMMUNE
    //                FROM WIS_SCORE_APA_RESULT
    //                WHERE (PAT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedPreScoringResultDetailByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, PERCEPTION, WET, ACTIVITIES, 
    //                            MOVE, NUTRITION, FRICTION, MEMO
    //                            FROM MED_PRE_SCORING_RESULT_DETAIL
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedPreScoringResultDetailByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, PERCEPTION, WET, ACTIVITIES, 
    //                MOVE, NUTRITION, FRICTION, MEMO
    //                FROM MED_PRE_SCORING_RESULT_DETAIL
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedCpisScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, SECRETIONS, BREAST, FEVER, 
    //                            PERIPHERAL, PAO2, BACTERIAL, MEMO
    //                            FROM MED_CPIS_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedCpisScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT BACTERIAL, BREAST, FEVER, MEMO, PAO2, PATIENT_ID, PERIPHERAL, SCORING_DATE_TIME, SECRETIONS,
    //                VISIT_ID FROM MED_CPIS_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedRtsScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, GCS, SBP, R, RESERVED01, 
    //                            RESERVED02, RESERVED03, MEMO
    //                            FROM MED_RTS_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedRtsScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, GCS, SBP, R, RESERVED01, 
    //                RESERVED02, RESERVED03, MEMO
    //                FROM MED_RTS_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }

    //        public string Score_GetMedSirsSScoringResultByPatientInfoAndDateTime
    //        {
    //            get
    //            {
    //                return @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, TEMPERATURE, HEART_RATE, 
    //                            BREATH_FREQUENCY, WBC, RESERVED01, RESERVED02, RESERVED03, MEMO
    //                            FROM MED_SIRS_S_SCORING_RESULT
    //                            WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)
    //                            ( SCORING_DATE_TIME = :dateTime)";
    //            }
    //        }

    //        public string Score_GetMedSirsSScoringResultByPatientInfo
    //        {
    //            get
    //            {
    //                return
    //                @"SELECT PATIENT_ID, VISIT_ID, SCORING_DATE_TIME, TEMPERATURE, HEART_RATE, 
    //                BREATH_FREQUENCY, WBC, RESERVED01, RESERVED02, RESERVED03, MEMO
    //                FROM MED_SIRS_S_SCORING_RESULT
    //                WHERE (PATIENT_ID = :patientID) AND (VISIT_ID = :visitID) AND (DEP_ID =:depID)";
    //            }
    //        }
    //    }
}
