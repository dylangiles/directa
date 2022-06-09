grammar Directa;

program: line* EOF;

line: statement | ifBlock | whileBlock;

statement: (declaration | returnStatement | functionCall) ';';

ifBlock: 'if' expression block ('else' elseIfBlock)?;
elseIfBlock: block | ifBlock; 

whileBlock: WHILE expression block;

block: '{' line* '}';

type: ('integer' | 'float' | 'boolean' | 'string' | IDENTIFIER);
declaration: IDENTIFIER ':' type ('=' expression)?;

functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';

expression
    : constant                              #constantExpression 
    | IDENTIFIER                            #identifierExpression
    | functionCall                          #functionCallExpression
    | '(' expression ')'                    #bracketedExpression
    | '!' expression                        #notExpression
    | expression multOp expression          #multiplicativeExpression
    | expression addOp expression           #additiveExpression
    | expression compareOp expression       #comparitiveExpression
    | expression boolOp expression          #booleanExpression
    ; 

returnStatement: 'return' expression?;
multOp: '*' | '/' | '%' | '**';
addOp: '+' | '-';
compareOp: '==' | '<>' | '>' | '<' | '>=' | '<=';
boolOp: BOOLEAN_OPERATOR;

constant: INTEGER | FLOAT | STRING | BOOLEAN | NULL;

RETURN: 'return';
BOOLEAN_OPERATOR: 'and' | 'or' | 'xor'; 
INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+ ;
STRING: ('"' ~'"'* '"');
BOOLEAN: 'true' | 'false'; 
NULL: 'null';
 
WHILE: 'while';
WS: [ \t\r\n]+ -> skip;
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;