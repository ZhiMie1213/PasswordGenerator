using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator {
    public class Functions {
        public static ( int, bool ) ParseArgs( string[ ] args ){
            if ( args.Length < 1 ) return ( 10, true );

            int digits = 10;
            if ( !int.TryParse( args[ 0 ], out digits ) ){
                digits = 10;
            }

            if ( args.Length < 2 ) return ( 10, true );
            bool useMark = args[ 1 ] != "0";

            return ( digits, useMark );
        }

        public static char GetPasswordLetter( char[ ] big, char[ ] little, char[ ] number, System.Random rand, bool useMark ) {
            char[ ] target;
            //まずはどの配列から文字を選ぶかサイコロをふる
            int randMax;
            if( useMark )
                randMax = 4;
            else
                randMax = 3;
            
            switch( rand.Next( 3 ) ){
                case 0:
                    target = big;
                    break;
                case 1:
                    target = little;
                    break;
                case 2:
                    default:
                        target = number;
                        break;
            }

            //次にtargeの中からランダムな文字を選ぶ
            return target[ rand.Next( target.Length ) ];
        }
    }
}
