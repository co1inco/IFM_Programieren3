grammar Language;


start : statement* EOF;


statement : assignment comment?; 

assignment : IDENTIFIER ASSIGNMENT expression; 

expression : expression comparison expression
		   | expression binaryOperation expression
		   | literal
		   | identifier;

comparison : EQUALS
		   | NOT_EQUALS
		   | LESS_THAN_OR_EQ
		   | LESS_THAN
		   | GREATER_THAN_OR_EQ
		   | GREATER_THAN
		   ;

binaryOperation : MULTIPLY
				| DIVIDE
				| MODULO 
				| ADD
				| SUBTRACT;

literal : INT
		| STRING
		| CHAR;

identifier : IDENTIFIER;

comment : COMMENT;


// Lexer
IDENTIFIER : [a-zA-Z_][a-zA-Z0-9_]*;

EQUALS: '==';
NOT_EQUALS: '!=';
LESS_THAN: '<';
GREATER_THAN: '>';
LESS_THAN_OR_EQ: '<=';
GREATER_THAN_OR_EQ: '>=';

ADD: '+';
SUBTRACT: '-';
MULTIPLY: '*';
DIVIDE: '/';
MODULO: '%';

ASSIGNMENT : ':='; 
COMMA : ',' ;
SEMI : ';' ;
LPAREN : '(' ;
RPAREN : ')' ;
LCURLY : '{' ;
RCURLY : '}' ;

INT : [0-9]+ ;
STRING: '"'(~('"')|(' '|'\b'|'\f'|'r'|'\n'|'\t'|'\\"'|'\\'))*'"';
CHAR: '\''(~('\'')|(' '|'\b'|'\f'|'r'|'\n'|'\t'|'\\\''|'\\'))'\'';

SPACES1: [ \t\n\r\f]+ -> skip ;
NEWLINE : '\r'? '\n' ;
//REST_OF_LINE : ~[\r\n]*; 
COMMENT : '#'~[\r\n]*;
