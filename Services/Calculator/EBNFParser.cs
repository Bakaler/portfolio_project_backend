

// _exp:=
//     =
//     exp '+' term
//     exp '-' term
//     term
// _term ::=
//     term '*' factor
//     term '/' factor
//     term '//' factor
//     term '%' factor
//     factor
// _factor ::=
//     '(' exp ')'
//     power
// _power ::=
//     digit '**' factor
//     function
// _function ::=
//     [digit | function ] [abs | sqrt | 1/x | n! | 10^y | x^y | log | neg]
//     digit
// _digit :: =
//     int '.' int
//     int
// _int ::=
//     int int
//     [0 | 1 | 2 | ... | 9]
public class EBNFParser
{
        // self._equationLine : str = ""
        // self._equationLineFlag : bool = False

        // self._commandLine : str = ""
        // self._commandLineFlag : bool = True

        // self._userInput  : str = ""
        // self._trailingInput = [False]

        // self._errorStatus = False

        // # Key : List[Regex String, Input String]
        // self._functionMap : dict = functionMap
        // self._operands = {"+", "-", "*", "**", "/", "%", "//"}


}