
grammar test;

program : SPACE* expr (SPACE+ expr)* SPACE* EOF;

list : LPAREN SPACE* expr? (SPACE+ expr)* SPACE* RPAREN;
dottedList : LPAREN SPACE* (expr SPACE+)* '.' SPACE+ expr SPACE* RPAREN;
quotedList : QUOTE expr;

expr : (number | bool | string | atom | dottedList | quotedList | list) SPACE* comment?;

atom : (LETTER | SYMBOL) (LETTER | DIGIT | SYMBOL)*;

number : DIGIT+;

bool : TRUE | FALSE;

string : STRING;

comment : COMMENT;

// hash : '#' (TRUE | FALSE);
// TRUE: 't';
// FALSE: 'f';

// Terminale

TRUE : 'true';
FALSE: 'false';

SYMBOL: [!#$%&|*+-/:<=>?@^_~];
LETTER: [A-Za-z];
DIGIT: [0-9];
STRING: '"'(~('"')|(' '|'\b'|'\f'|'r'|'\n'|'\t'|'\\"'|'\\'))*'"';

QUOTE: '\'';

COMMENT : ';;'~[\r\n]*;

SPACE : [ \t\n\r\f];
//SPACES: [ \t\n\r\f]*;
//SPACES1: [ \t\n\r\f]+;
// SPACES: [ \t\n\r\f]+ -> skip;
LPAREN : '(' ;
RPAREN : ')' ;