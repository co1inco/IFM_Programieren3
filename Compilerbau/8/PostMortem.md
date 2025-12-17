# Post mortem

Jede Person beschreibt in der ILIAS-Abgabe individuell(!) die Bearbeitung des jeweiligen Aufgabenblattes
zurückblickend mit ca. 200 bis 400 Wörtern. Gehen Sie dabei aussagekräftig und nachvollziehbar auf folgende Punkte ein: 
 (a) Zusammenfassung: Was wurde gemacht? 
 (b) Implementierungsdetails: Kurze Beschreibung besonders interessanter Aspekte der Umsetzung. 
 (c) Was war der schwierigste Teil bei der Bearbeitung? Wie haben Sie dieses Problem gelöst? 
 (d) Was haben Sie gelernt oder (besser) verstanden? 
 (e) Team: Mit wem haben Sie zusammengearbeitet? 
 (f) Link zum Repo mit der Lösung 



 
 * a: Deses Praktikum war als einführung in P++ gedacht. Wir sollten einen kleinen Lexer implementieren. Dafür sollte eine eingene version des std::shared_ptr implementiert werden, da hier die Speicherverwaltung und die Big 3 / 5 bzw. Copy und Move Semantik Anwendung finden. Zum Schluss sollten wir noch einen Ringpuffer implementieren, bei den der Speicher wiederverwendet wird.
 * b: Da ich bereits vorgeschädigt bin, konnte ich ich den SharedPtr als template Klasse anlegen. 
 * c: Ich hatte Probleme mit dem lexer, wodurch der nicht fertig geworden ist. Ich bin mir nicht sicher, ob ich Geister gejagt habe, oder aber tatsächlich mehrere Probleme hatte. Letztendlich hat sich aber herausgestellt, dass der Lexer eine Diskrepanz hatte. Die peak() Methode war bereits am EOF, der Token, der zurückgegeben wurde hat das aber nicht reflektiert, wodurch die tokenize() Methode nicht mitbekommen hat, dass der Lexer eigentlich schon fertig ist.
 * d: Mir waren copy und move vorher noch nicht so klar. Vor allem copy war mir in der Vergangenheit hauptsächlich ein begriff, weil CLion rum gemekert hat, dass ich doch bitte einen expliziten copy construktor anlegen soll.
 * e: -
 * f: https://github.com/co1inco/IFM_Programieren3/tree/master/Compilerbau/8