grammar MiniC;

// Parser
program : stmt+ EOF ;

stmt
  : vardecl
  | assign
  | fndecl
  | expr ';'
  | block
  | while
  | cond
  | return
  ;

vardecl : type ID ('=' expr)? ';' ;
assign  : ID '=' expr ';' ;

fndecl  : type ID '(' params? ')' block ;
params  : type ID (',' type ID)* ;
return  : 'return' expr ';' ;

fncall  : ID '(' args? ')' ;
args    : expr (',' expr)* ;

block   : '{' stmt* '}' ;
while   : 'while' '(' expr ')' block ;
cond    : 'if' '(' c=expr ')' if=block ('else' else=block)? ;


expr
  : fncall
  | left=expr binop=('*' | '/') right=expr
  | left=expr binop=('+' | '-') right=expr
  | left=expr binop=('>' | '<') right=expr
  | left=expr binop=('==' | '!=') right=expr
  | ID
  | NUMBER
  | STRING
  | true='T'
  | false='F'
  | '(' expr ')'
  ;

type : 'int' | 'string' | 'bool' | 'void' ;


// Lexer
ID      : [a-zA-Z] [a-zA-Z0-9]* ;
NUMBER  : [0-9]+ ;
STRING  : '"' (~[\n\r"])* '"' ;

COMMENT : '#' ~[\n\r]* -> skip ;
COMMENT2 : '//' ~[\n\r]* -> skip ;
WS      : [ \t\n\r]+   -> skip ;