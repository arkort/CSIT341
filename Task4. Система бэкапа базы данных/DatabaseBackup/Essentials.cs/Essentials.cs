using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBackup.Essential
{
    public static class Essentials
    {
        public static readonly string getAllForeignKeysQuery = @"SELECT
	                                    FK_Schema = FK.TABLE_SCHEMA,
                                        FK_Table = FK.TABLE_NAME,
                                        FK_Column = CU.COLUMN_NAME,
                                        PK_Schema = PK.TABLE_SCHEMA,
	                                    PK_Table = PK.TABLE_NAME,
                                        PK_Column = PT.COLUMN_NAME,
                                        Constraint_Name = C.CONSTRAINT_NAME,
		                                On_Delete = C.DELETE_RULE,
		                                On_Update = C.UPDATE_RULE
                                    FROM
                                        INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK
                                        ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK
                                        ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                                    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU
                                        ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
                                    INNER JOIN (
                                                SELECT
                                                    i1.TABLE_NAME,
                                                    i2.COLUMN_NAME
                                                FROM
                                                    INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
                                                INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2
                                                    ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
                                                WHERE
                                                    i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
                                                ) PT
                                        ON PT.TABLE_NAME = PK.TABLE_NAME";

        public static readonly string getAllFunctionsQuery = @"SELECT ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'FUNCTION'";

        public static readonly string getAllPrimaryKeyConstraintsQuery = @"SELECT  tc.CONSTRAINT_NAME, tc.TABLE_SCHEMA, tc.TABLE_NAME, cu.COLUMN_NAME
	                                                                        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc
		                                                                        INNER JOIN(SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE) AS cu
		                                                                        ON tc.CONSTRAINT_NAME = cu.CONSTRAINT_NAME
                                                                        WHERE CONSTRAINT_TYPE = 'PRIMARY KEY'";

        public static readonly string getAllSequencesQuery = @"SELECT infS.SEQUENCE_SCHEMA, infS.SEQUENCE_NAME, infS.DATA_TYPE, infS.START_VALUE, infS.INCREMENT, infS.MINIMUM_VALUE, infS.MAXIMUM_VALUE, ss.is_cached FROM INFORMATION_SCHEMA.SEQUENCES as infS
INNER JOIN (SELECT name, is_cached FROM sys.sequences) as ss
ON ss.name = infS.SEQUENCE_NAME";

        public static readonly string getAllStoredProceduresQuery = @"SELECT ROUTINE_DEFINITION FROM INFORMATION_SCHEMA.ROUTINES
                                        WHERE ROUTINE_TYPE = 'PROCEDURE'";

        public static readonly string getAllSynonymsQuery = @"SELECT name, base_object_name FROM sys.synonyms";
        public static readonly string getAllTablesQuery = "SELECT TABLE_SCHEMA, TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

        public static readonly string getAllUniqueConstraintsQuery = @"SELECT tc.CONSTRAINT_SCHEMA, tc.CONSTRAINT_NAME,  tc.TABLE_SCHEMA, tc.TABLE_NAME, cu.COLUMN_NAME
	        FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc
	        INNER JOIN(SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE) AS cu
	        ON tc.CONSTRAINT_NAME = cu.CONSTRAINT_NAME
	        WHERE tc.CONSTRAINT_TYPE = 'UNIQUE'";

        public static readonly string getAllViewsQuery = @"SELECT VIEW_DEFINITION FROM INFORMATION_SCHEMA.Views";
    }
}