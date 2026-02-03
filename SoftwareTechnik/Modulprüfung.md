
Um die Implementierung von Softwareprodukten zu vereinfachen, zu beschleunigen und im Team zu koordinieren, ist es sinnvoll, ein Softwareprodukt vor der Implementierung gedanklich zu entwerfen. Dazu werden die technischen und nicht-technischen Anforderungen an das
Softwareprodukt eindeutig, konsistent und so vollständig wie möglich beschrieben.
 # 1 Aufgabenbeschreibung
Weiter unten finden Sie Informationen und Anforderungen an ein Softwareprodukt in natürlicher Sprache. Diese Anforderungen wurden in einem Workshop mit Interessierten und Beteiligten nach sorgfältiger Untersuchung notiert. Die Anforderungen stellen unter anderem dar, welche Funktionalitäten das Softwareprodukt implementieren muss und welche Daten zu speichern sind. Der Workshop verlief chaotisch, da viele Personen mit unterschiedlichen Interessen, Begriffen und Ansichten teilgenommen haben. Daher können die Anforderungen ungeordnet, doppelt, unvollständig, mehrdeutig, widersprüchlich oder sprachlich inkonsistent sein. Untersuchen Sie daher die unten beschriebenen Informationen und Anforderungen an das Softwareprodukt und erstellen Sie dafür eine technische Spezifikation in der Art und Weise, wie Sie es im Praktikum gelernt haben. Benutzen Sie für die Beschreibung der Softwarearchitektur das 4+1-Sichten-
Softwarearchitekturmodell. Erstellen Sie für die einzelnen Sichten der Softwarearchitektur separate Kapitel und fügen Sie sämtliche zu modellierenden Aspekte in geeignete Kapitel des Softwarearchitekturdokuments ein.Lesen und analysieren Sie die Anforderungen sorgfältig und überprüfen Sie die Anforderungen auf Widersprüche und Unvollständigkeiten. Identifizieren und modellieren Sie im Softwarearchitekturdokument folgende relevante Sachverhalte:

 ## 1.1 Funktionale und nicht-funktionale Anforderungen
Finden Sie einen aussagekräftigen Namen für das Softwareprodukt, der die Funktionalität des Softwareprodukts ansprechend zum Ausdruck bringt. Identifizieren Sie und dokumentieren Sie sämtliche Aktoren (Akteure) Dokumentieren Sie die funktionalen Anforderungen in Form von User Stories mit Namen, Akzeptanzkriterien und MoSCoW-Priorisierung in einer Tabelle mit sechs Spalten anhand
folgender beispielhaften Schablone:

| Name/ID | In meiner Rolle als...... | möchte ich... | ..., so dass... | Akzeptiert, wenn... | Priorität |
| ------- | ------------------------- | ------------- | --------------- | ------------------- | --------- |
| Lösung anzeigen | Benutzer | bei Fehleingabe die Lösung angezeigt bekommen | ich lernen kann | Lösung wird angezeigt | Muss |

 * Identifizieren und dokumentieren Sie funktionalen Gruppen (wie z.B. Profilverwaltung,...), in denen mehrere User Stories kategorisiert werden können. Fügen Sie für jede einzelne funktionale Gruppe ein separates Unterkapitel in das Dokument ein.
 * Modellieren Sie die Funktionalität des Softwareprodukts so umfangreich, sorgfältig und detailliert wie möglich und in voller Gänze.Beschreiben Sie nicht-funktionale Anforderungen und Qualitätsmerkmale anhand der ISO 25010.
 * Überprüfen Sie die (nicht-)funktionalen Anforderungen auf Unvollständigkeiten und ergänzen Sie fehlende Funktionalitäten, die Sie hilfreich und für den sinnvollen Ablauf der Software als notwendig erachten, aber nicht in den Anforderungen zu finden sind.
 * Stellen Sie die Begriffe der Fachdomäne des Softwareprodukts in einem Glossar dar

## 1.2 Graphische Benutzungsschnittstelle
Entwerfen Sie die graphische Benutzungsschnittstelle mit GUI-Mockups für sämtliche
Akteure.Achten Sie darauf, dass die GUI-Mockups zu den User Stories / funktionalen Gruppen
passen müssen.
Entwerfen Sie die Mockups sowohl für mobile Endgeräte als auch für Webbrowser, sofern
Ihr Team aus zwei oder drei Mitgliedern besteht.Stellen Sie unter den Dialogen/Screens dar (bzw. verlinken Sie im Dokument), welche
User Stories mit dem jeweiligen Dialog/Screen abgehandelt werden.Modellieren Sie die Navigation zwischen den Screens der GUI-Mockups als
Zustandsdiagramm und fügen Sie diese Diagramme jeweils als Überblick vor den
Mockups in das Dokument ein. Sollte sich die Navigation für unterschiedliche Akteure
unterscheiden, so modellieren Sie mehrere Zustandsdiagramme. Dies gilt auch für
unterschiedliche Navigationen bei Webbrowser und mobile Endgeräte.Legen Sie dar, welche Prinzipien Sie für das Design der graphischen
Benutzungsschnittstelle berücksichtigt haben.Finden Sie eine geeignete Inhaltsstruktur (z.B. geordnet nach Akteuren oder funktionalen
Gruppen) und fügen Sie dementsprechend Unterkapitel etc. in das Dokument ein.Kennzeichnen Sie die Dialoge/Screens mit Überschriften, so dass diese im
Inhaltsverzeichnis erscheinen.

## 1.3 Datenmodell
Entwerfen Sie für die beschriebenen Softwareprodukt-Anforderungen Modelle für die
persistent zu speichernden Daten, indem Sie das konzeptionelle/fachliche
Datenmodell/Domänenmodell mit einem Domänen-Klassendiagrammen in der UML-
Notation definieren. Modellieren Sie hierbei also Klassen, ungerichtete Beziehungen
zwischen diesen Klassen, Multiplizitäten der Beziehungen sowie die Beziehungsarten
Vererbung, Aggregation und Komposition. Ergänzen Sie fehlende Klassen und Attribute,
die Sie für die vollständige Abbildung der Domäne als sinnvoll erachten.Modellieren Sie die Zustandsübergänge einzelner Klassen mit einem UML-
Zustandsdiagramm.Überführen Sie das fachliche Datenmodell in ein logisches Datenmodell. Modellieren Sie
dazu im Detail sämtliche Attribute, unidirektionale Beziehungsrichtungen und löschen
Klassen, deren Daten für das Softwareprodukt irrelevant sind. Fügen Sie Klassen für
Bewegungsdaten hinzu, die im zeitlichen Durchlauf der Software erzeugt werden.Achten Sie bei der Erstellung der Datenmodelle darauf, dass die Datenmodelle zu den
Daten passen, die Sie in den GUI-Mockups darstellen.Erstellen Sie eine CRUD-Matrix und prüfen Sie, ob die funktionalen User Stories zu den
fachlichen Klassen passen und die Operationen vollständig sind.

## 1.4 Schnittstellen und Systemarchitektur
Beschreiben Sie die System-Schnittstellen (API) für Bestandteile/Komponenten des
verteilten Softwaresystems, insbesondere die REST-API des Servers.
Als Format für die API-Beschreibung kann die OpenAPI-Spezifikation verwendet werden.
Sie können die Beschreibung der API in das Dokument einfügen oder als separate Datei
zusammen mit der .pdf-Datei des Dokuments in einer zip-Datei abgeben.Stellen Sie für relevante User Stories die logisch-zeitlichen Abläufe von Aktoren und
Softwarebausteinen des Client-Server-Softwaresystems in UML-Sequenzdiagrammen dar.Modellieren Sie die Drei-Stufen-Systemarchitektur des Softwaresystems mit einem UML-
Verteilungsdiagramm, aus dem sämtliche beteiligten Hardware-Ressourcen (Clients,
Server etc.) zu erkennen sind.Identifizieren Sie mögliche Sicherheitsrisiken und Sicherheitsschwachstellen und
beschreiben Sie, wie Sie diese verhindern wollen. Führen Sie dazu eine
Bedrohungsmodellierung mittels STRIDE durch. Stellen Sie dabei nicht nur die
Bedrohungen dar, sondern zeigen Sie auch mögliche Schutzmaßnahmen auf, die die
Bedrohungen entschärfen.

# Automatic Zoom
Als Format für die API-Beschreibung kann die OpenAPI-Spezifikation verwendet werden.
Sie können die Beschreibung der API in das Dokument einfügen oder als separate Datei
zusammen mit der .pdf-Datei des Dokuments in einer zip-Datei abgeben.Stellen Sie für relevante User Stories die logisch-zeitlichen Abläufe von Aktoren und
Softwarebausteinen des Client-Server-Softwaresystems in UML-Sequenzdiagrammen dar.Modellieren Sie die Drei-Stufen-Systemarchitektur des Softwaresystems mit einem UML-
Verteilungsdiagramm, aus dem sämtliche beteiligten Hardware-Ressourcen (Clients,
Server etc.) zu erkennen sind.Identifizieren Sie mögliche Sicherheitsrisiken und Sicherheitsschwachstellen und
beschreiben Sie, wie Sie diese verhindern wollen. Führen Sie dazu eine
Bedrohungsmodellierung mittels STRIDE durch. Stellen Sie dabei nicht nur die
Bedrohungen dar, sondern zeigen Sie auch mögliche Schutzmaßnahmen auf, die die
Bedrohungen entschärfen.

# 2 Hinweise, Formales, Termine

## 2.1 Allgemein
Die Softwarespezifikation muss allein oder zu zweit oder zu dritt und in deutscher Sprache
angefertigt werden.Die Studenten, mit denen Sie zusammen die Modulprüfung ablegen, müssen nicht
dieselben sein, mit denen Sie die Praktikumsaufgabe beabeitet haben.Verteilen Sie die Aufgaben und Verantwortlichkeiten gleichmäßig auf die Teammitglieder
und dokumentieren Sie diese Verteilung in der technischen Spezifikation.Die Softwarespezifikation kann mit beliebigen Werkzeugen zur Textverarbeitung (Word,
Latex, etc.) geschrieben werden.Für die Modellierung von UML-Diagrammen, für das Erstellen von GUI-Mockups und
säntlichen weiteren Diagrammen können Sie eine beliebige Software nutzen. Fügen Sie die
erzeugten Diagramme und Mockups etc. in geeignete Kapitel Ihres Softwarespezifikations-
Dokument ein.
# 2.2 Inhalt
Finden Sie gemäß des 4+1-Sichten-Softwarearchitekturmodells eine geeignete
Inhaltsstruktur und fügen Sie die modellierten Sachverhalte in entsprechende Kapitel der
Softwarespezifikation ein. Stellen Sie diese Inhaltsstruktur als Inhaltsverzeichnis an den
Anfang des Dokuments dar.Achten Sie darauf, dass die Inhalte thematisch miteinander integriert sind und einen
logischen Zusammenhang darstellen. Dies gilt insbesondere dann, wenn Sie die
Projektarbeit zu zweit oder zu dritt durchführen und die Teilaufgaben untereinander
aufteilen und später integrieren müssen.Es existieren keine Anforderungen an die minimale oder maximale Seitenanzahl des
Dokuments.Stellen Sie eine Selbstständigkeitserklärung (s.u.) an den Anfang der Arbeit.Fügen Sie ein Titelblatt mit den Vor- und Nachnamen sowie der Matrikelnummer aller
beteiligten Studenten in das Dokument ein.Fügen Sie ggfs. Sachverhalte hinzu, die Sie für relevant halten.

## 2.3 Abgabe
Die Abgabe der Softwarespezifikation im Dateiformat ".pdf“ geschieht in ILIAS. Enthält
Ihre Abgabe mehrere Dateien, so benutzen Sie das zip-Dateiformat.Als Dateinamen (z.B. „Softwarespezifikation_Mueller_Meier_Schneider.pdf“) für das
Dokument verwenden Sie alle Nachnamen der Studenten, die an der Erstellung des
Dokuments beteiligt waren.Beachten Sie den Abgabetermin für die Softwarespezifikation im ILIAS. Später
eingehende Abgaben werden mit „mangelhaft“ bewertet.Sie können die Projektarbeit in der zweiten Klausurphase bearbeiten. Dazu müssen Sie
sich für die Modulprüfung für den zweiten Termin im LSF anmelden. Der Abgabetermin
und weitere Formalitäten für die zweite Klausurphase werden im Etherpad im ILIAS
bekanntgegeben.

## 2.4 Bewertungkritierien
Folgende Kriterien werden für die Bewertung sämtlicher erzeugten Artefakte benutzt:Logischer inhaltlicher ZusammenhangSorgfalt, Verständlichkeit, Vollständigkeit und Komplexität der modellierten
Funktionalität hinsichtlich der Softwareprodukt-AnforderungenTechnische Qualität und Korrektheit sämtlicher DiagrammeKreativität der Umsetzung der Softwareprodukt-AnforderungenTeamarbeit und gleichverteilte AufgabenverteilungUmfang der Softwarespezifikation in Relation zur TeamgrößeInterpunktion, Groß- und Kleinschreibung sowie Rechtschreibung
SelbstständigkeitserklärungHiermit versichere ich, dass ich die vorliegende Arbeit selbstständig und ohne die Benutzung
anderer als der angegebenen Hilfsmittel angefertigt habe. Alle Stellen - einschließlich Tabellen,
Karten, Abbildungen etc. -, die wörtlich oder sinngemäß aus veröffentlichten und nicht
veröffentlichten Werken und Quellen (dazu zählen auch Internetquellen) entnommen wurden,
sind in jedem einzelnen Fall mit exakter Quellenangabe kenntlich gemacht worden.Zusätzlich versichere ich, dass ich beim Einsatz von generativen IT-/KI-Werkzeugen (z.B.
ChatGPT, BARD, Dall-E oder Stable Diffusion) diese Werkzeuge in einer Rubrik "Übersicht
verwendeter Hilfsmittel“ mit ihrem Produktnamen, der Zugriffsquelle (z. B. URL) und Angaben
zu genutzten Funktionen der Software sowie Nutzungsumfang vollständig angeführt habe.
Wörtliche sowie paraphrasierende Übernahmen aus Ergebnissen dieser Werkzeuge habe ich
analog zu anderen Quellenangaben gekennzeichnet.Mir ist bekannt, dass es sich bei einem Plagiat um eine Täuschung handelt, die gemäß der
Prüfungsordnung sanktioniert werden wird.Ich versichere, dass ich die vorliegende Arbeit oder Teile daraus nicht bereits anderweitig
innerhalb und außerhalb der Hochschule als Prüfungsleistung eingereicht habe.Ort, Datum Name, Matrikelnummer

# 3 Anforderungen an das Softwareprodukt
Verwaltung von Veranstaltungen
Die digitale Planung, Organisation, Durchführung und Nachbereitung von privaten und
öffentlichen Veranstaltungen bzw. Events in Gruppen wie beispielsweise Reisen (Skiurlaub etc.)
oder Feste (Grillfest etc.) ist oft unübersichtlich und anstrengend. Über verschiedene
Messenger-Dienste (WhatsApp etc.) werden Gruppen erstellt und über andere Dienste (Doodle
etc.) werden zusätzlich dazu Umfragen erstellt. Dies geschieht aus Bequemlichkeit, weil viele
Menschen bereits Messenger-Dienste nutzen und dann eine Online-Gruppe bilden, in der
relevante Informationen notiert werden. Wichtige Termine und weitere Daten werden schnell
vergessen oder müssen in langen Chats gesucht werden. Außerdem muss für eine Reise oft auch
Geld eingesammelt werden und es fällt bei den Einzahlungen schwer, den Überblick zu
behalten, wer bereits wieviel gezahlt hat. Es besteht daher der Wunsch, sämtliche Daten eines zu
planenden Events mit einer Software zu verwalten. Da bislang keine Software mit solchen
Features existiert, soll ein Softwareprodukt erstellt werden, so dass sich größere Gruppen für
den Urlaub oder für Feste besser organisieren können, indem die relevanten Daten ganzheitlich
erfasst und übersichtlich dargestellt werden. Informationen über Orte, Finanzen oder
Absprachen können schnell gefunden werden, weil alle wichtigen Daten zentral an einem Ort
zur Verfügung stehen. Aber nicht nur Privatnutzer wollen Veranstaltungen durchführen,
sondern auch kommerzielle Anbieter. Beide Nutzergruppen möchten ebenfalls die Dienste von
professionellen Veranstaltungs-Dienstleistern in Anspruch nehmen, die die reibungslose
Durchführung von Veranstaltungen sicherstellen. Daher wird ein Softwareprodukt benötigt, mit
dem man sich registrieren und anmelden können muss. Zur Anmeldung benötigt man einen
Benutzernamen und ein Passwort. Das Passwort muss man zurücksetzen können. Hat man noch
keinen Account, muss man sich zunächst registrieren. Zum Registrieren wird ein Vorname,
Nachname, E-Mail-Adresse, Benutzername und ein Passwort, das zweimal eingetippt werden
muss, benötigt. Sämtliche Daten muss das Softwareprdukt sicher speichern. Insbesondere das
Passwort muss unleserlich in der Datenbank gespeichert werden. Dazu soll das Passwort
„gehasht“ und „gesalted“ werden. Nach der Anmeldung erhält man die Übersicht über die
Gruppen, die man erstellt hat und denen man beigetreten ist und denen man beitreten kann.
Diese Liste ist sortiert und man kann die Liste nach Merkmalen sortieren. Man kann eine oder
mehrere Gruppen erstellen, wobei für die Erstellung der Name der Gruppe und eine
Beschreibung benötigt wird. Man kann auch bereits erstellten Gruppen beitreten. Selbst
erstellte Gruppen können gelöscht werden. Gruppen können für eine gewisse Zeit erstellt
werden, danach werden sie automatisch archiviert oder gelöscht. Für eine Gruppe kann die
Liste der Mitglieder angezeigt werden. Zu einer Gruppe können andere Menschen eingeladen
werden. Eine solche Gruppe bekommt einen automatisch zufällig generierten Beitrittscode, der
für andere Mitglieder benötigt wird, damit diese der Gruppe beitreten können. Mitglieder
können die Gruppe eigenständig verlassen. Man kann angeben, welche Mindestanzahl von
Teilnehmern vorhanden sein muss, damit das Event überhaupt stattfindet. Außerdem ist es
möglich, ein Event nur dann stattfinden zu lassen, wenn genügend Zahlungen eingegangen sind.
Jeder potentielle Teilnehmer kann dabei eine beliebige Geldsumme (jedoch existiert ein
Mindestbeitrag) einzahlen, auch denn, wenn die Mindestgeldsumme bereits erreicht ist. Es wird
den Teilnehmern angezeigt, wieviel Geld bereits eingegangen ist, was die Mindestgeldsumme ist
und wieviel Geld noch bis zum Erreichen benötigt wird. Diese Angaben sind auf der „Profilseite“
bzw. „Homepage“ jedes Events ersichtlich. Diese Profilseite kann vom Organisator zum
Vermarkten verwendet werden, da die URL eindeutig ist und nach Erzeugung nicht mehr
geändert wird. Für diese URL wird ein QR-Code angezeigt, sodass die URL nicht mühsam
eingetippt werden muss. Wählt man eine Gruppe aus der Gruppenliste aus, wird der
Gruppenname und daneben den Beitrittscode sowie weitere relevante Informationen angezeigt.
Darunter folgen dann sämtliche Notizen. Notizen können Ausgaben (z.B. „10 Euro für
Grillkohle“), Umfragen (z.B. „Wo wollen wir den Urlaub verbringen?“), Termine (z.B. Zeit und
Ort einer Zugabfahrt) und Anmerkungen sein. Man soll sämtliche Notizen der Gruppe sehen
können. Notizen können erstellt und wieder gelöscht und auch geändert werden. Jeder Notiztyp
hat eine bestimmte Farbe, um die Übersicht zu behalten. Sortiert sind die Notizen nach dem
Erstellungsdatum. Die neueste Notiz steht ganz oben. Man hat so eine einfache und geordnete
Übersicht über wichtige Dinge, so dass die Informationen schnell erkannt werden können.
Notizen können gefiltert werden, so dass man sich zum Beispiel nur Ausgaben oder nur
Umfragen ansehen kann. Organisatoren können auch Umfragen einrichten, um vor oder nach
dem Event ein Feedback zur Meinungs- oder Zufriedenheitserfassung zu etablieren. Bei den
Umfragen sieht man eine Verteilung, wie viele Mitglieder für welche Antwort gestimmt haben.
Bei der Erstellung von Umfragen kann man dynamisch die Anzahl von Antwortmöglichkeiten
bestimmen. Jeder kann Umfragen erstellen und jeder kann an diesen Umfragen teilnehmen. Bei
den Umfragen kann festgelegt werden, ob mehrere Antworten ausgewählt werden können oder
nur eine. Bei den für alle sichtbaren Ausgaben sollen am Ende die gesamten Ausgaben
übersichtlich dargestellt werden, um so sehen zu können, welche Person wieviel bezahlt hat. Die
Mitglieder können auch Einzahlungen vornehmen. Ausgaben werden mit Preis und einer
Bezeichnung erfasst. Neben einzelnen Ausgaben gibt es auch einen Kassensturz, bei dem man
eine Übersicht über alle Ausgaben der Gruppe und über die einzelnen Personen erhält.
Einzahlungen eines Mitglieds müssen gelöscht werden, wenn das Mitglied die Gruppe verlässt.
Der Organisator kann manuell eine Rückzahlung veranlassen. Bei der Registrierung kann man
die bevorzugte Datenkommunikation (SMS, E-Mail, Whatsapp, etc.) definieren. Wird eine
Einzahlung vorgenommen, erhält das Mitglied eine Dankesnachricht per bevorzugtem
Kommunikationsmedium. Während man bei den Anmerkungen einen Freitext eingeben kann,
können bei den Terminen wichtige Daten eingetragen werden, wie z.B. Zugverbindungen oder
Abfahrtszeit oder Gleisnummer. Oder man hat zum Beispiel für die Reise bereits irgendeine
Attraktion gebucht und dort wird dann Datum, Zeit und eine Bemerkung dazu erfasst. Die
Durchführung der Events kann man auch dokumentieren, indem man Kommentare bzw.
Bewertungen (z.B. „Unvergessliches Erlebnis“) und Multimedia-Dateien (z.B. Fotos oder
Videos) hochladen kann. Nachdem ein Event stattfinden kann, können Zeitpläne und noch ausstehende  Aufgaben  (z.B.  Grillfleisch  einkaufen)  erstellt  werden.  Diese  Aufgaben  werden
einzelnen Teilnehmern zugewiesen, die sich vorher zur Übernahme von Aufgaben bereit erklärt
haben. Aufgaben können als fertig markiert werden. Falls Aufgaben nicht bearbeitet werden,
sendet  das  Softwareprodukt  automatisch  Erinnerungen  an  die  entsprechenden  Teilnehmer.
Wichtige  Termine  können  per  Synchronisation  mit  Google  Calendar,  Outlook  oder  iCal
automatisch  aktualisiert  werden.  Funktionen  zum  Matchmaking  von  Event-Teilnehmern
(„Networking“) sowie Funktionen zum Nachrichtenaustausch zwischen sämtlichen Beteiligten
sind  ebenfalls  vorhanden.  Das  über  Smartphone  und  Desktop-Webbrowser  bedienbare
Softwareprodukt spricht Privatleute an, aber auch Institutionen wie Schulen und Firmen. Die
Sprache der Anzeigetexte ist auswählbar. Die Passwörter dürfen nicht in Klartext gespeichert
werden  und  die  Datenkommunikation  zwischen  Client  und  Server  muss  verschlüsselt  sein,
damit diese nicht so einfach von Unbefugten abzufangen ist. Die Software muss ohne lange
Einarbeitung bedienbar sein, sodass auch neue Mitarbeiter (Aushilfskräfte) schnell mit dem
System arbeiten können. Das Softwareprodukt soll Kompatibilität zu den aktuellen Versionen
der folgenden Browser aufweisen: Chrome, Edge, Firefox, Safari. Das Softwareprodukt soll ein
Client-Server-System  sein,  das  für  mobile  Endgeräte,  Webbrowser  und  digitale
Sprachassistenten  verfügbar  ist,  sehr  performant  ist,  für  sehr  viele  gleichzeitige  Benutzer
ausgelegt ist und auf aktuellen (mobilen) Betriebssystemen läuft. Das Softwareprodukt muss im
Webbrowser und als mobile App vollständig funktional konsistent sein, so dass alle Funktionen,
die mit dem Webbrowser genutzt werden können, auch mittels der mobilen App verfügbar sind.
Für Institutionen gibt es gesonderte Funktionalitäten, so dass die Software ein Rechtesystem
zwischen  Gruppenleiter  und  normalen  Mitglied  benötigt.  Ein  Gruppenleiter  (Ersteller  einer
Gruppe) kann Mitglieder aus der Gruppe entfernen und sperren sowie die Gruppe verwalten. So
erhält  beispielsweise  ein  Lehrer  zusätzliche  Rechte,  während  Schüler  nur  lesenden  Zugriff
haben. Unterschiedliche Rechte gelten zum Beispiel auch für unterschiedliche Personenrollen in
Firmen.  In  der  kostenlosen  Variante  des  Softwareprodukts  können  Institutionen  insgesamt
maximal drei Veranstaltungen nacheinander durchgeführt haben. Das Produkt wird ebenfalls in
einer Premium-Variante angeboten. Hier können beliebig viele Veranstaltungen durchgeführt
werden. In dieser Variante haben kommerzielle Institutionen (z.B. Anbieter von Kreuzfahrten)
zusätzlich  die  Möglichkeit,  mehrere  Events  anzubieten,  die  gleichzeitig  stattfinden.  Zeitlich
parallele  Events  sind  der  Community-Edition  nicht  möglich.  Eine  Integration  mit
Veranstaltungs-Dienstleistern („Event-Anbietern“) bzw. Ticketing (z.B. Eventim) ist möglich,
um die Veranstaltung selber sowie den Verkauf von digitalen Eintrittskarten abzuwickeln. In der
Premium-Variante können sich die kommerziellem Veranstaltungs-Dienstleister anmelden. Für
solche  Dienstleister  stehen  gesonderte  Features  für  den  Bereich  der  Planung  der
Veranstaltungstechnik  zur  Verfügung,  da  in  der  Veranstaltungstechnik  ein  hoher
Planungsbedarf an Ressourcen besteht, die einem Event zugeteilt werden und entsprechend
verwaltet werden müssen. Hierbei ist sowohl die Rede vom notwendigen Event-Equipment als
auch von Mitarbeitern bis hin zu Fahrzeugen. Hinzu kommt eine zeitliche wie auch logistische
Ablaufplanung. Ein Veranstaltungs-Dienstleister kann von einem Organisator / Veranstalter für
die Durchführung eines Events mit einem Maximalbudget angefragt werden. Dafür muss das
Softwareprdukt  für  die  Dienstleister  eine  „Homepage“  mit  QR-Code  anzeigen,  von  der  aus
Veranstalter  ein  Event  anfragen  können,  sodass  diese  Anfrage  direkt  dem  Dienstleister
angezeigt und von ihm bearbeitet werden kann. Da ein Veranstalter den gebuchten Dienstleister
nach der Durchführung bewerten kann, wird auf der Homepage ebenfalls eine Übersicht über
die Bewertungen (z.B. mit Sternen) dargestellt. Das Softwareprodukt erlaubt es, einen Überblick
über die Events eines Unternehmens zu erlangen, neue Events anzulegen und planen, bereits
durchgeführte Events zu archivieren und Kunden wie auch deren Rechnungen zu verwalten. Die
Ressourcen  (Mitarbeiter,  Event-Equipment,  Fahrzeuge,  etc.)  sollen  für  ein  Event  gebucht
werden können, wobei das vom Kunden gesetzte Budget eingehalten werden soll. Des Weiteren
sollen Dokumente wie Rechnungen oder Angebote automatisch generiert werden können. Wird
ein Event erzeugt, werden der Veranstaltungsort, ein Start- und Enddatum bzw. eine Start- und
Endzeit,  Veranstalter,  Budget  und  ein  Budget-Spielraum  gespeichert.  Eine
Veranstaltungsanfrage durch einen Kunden enthält in dem dafür zuständigen Formular den
Ort, das Start-/Enddatum bzw. Zeit, Veranstalter, Budget und Budget Spielraum. Es soll zu
jedem mehrtägigen Event angegeben werden können, wie viele der Tage sogenannte „Off-Days“
sind. In der Veranstaltungstechnik wird bei der Materialverleihung zwischen sogenannten „On-"
und „Off-Days“ unterschieden. Off-Days sind hierbei Tage an denen das entsprechende Gerät
nicht verwendet wird, also ausgeschaltet ist (bzw. bei Material ohne Stecker es nicht verwendet
wird); On-Days entsprechend umgekehrt. Die Off-Days werden in den Gesamtkosten rabattiert.
Die On- und Off-Days müssen nachträglich geändert werden können. Es soll nicht für jedes
Material der Verleihpreis für On- und für Off-Days gespeichert werden, sondern ausschließlich
der für On-Days. Jede Veranstaltungsanfrage soll weiterbearbeitet werden können und damit zu
einem Event „konvertiert“ werden können. Aus einer Anfrage soll ein Angebot generiert werden
können, welches automatisch an die vom Kunden angegebene E-Mail-Adresse weitergeleitet
und ebenfalls vom Softwareprodukt dargestellt wird. Hat der Veranstaltungs-Dienstleister das
Event  geplant,  kann  ein  Angebot  generiert  werden,  das  dem  Organisator  zugestellt  werden
kann. Dieses Angebot muss folgende Informationen beinhalten: Preis (Brutto / Netto / Rabatt),
Mitarbeiter  und  deren  Lohnkosten,  Materialkosten,  Fahrkosten,  Verwaltungskosten,  Kunde,
Datum  und  Dauer,  Ort,  Verfasser  des  Angebots,  Materialliste  sowie  Fotos  des  verwendeten
Materials. Der Veranstaltungs-Dienstleister kann Material (z.B. Boxen, LKWs) und Mitarbeiter
verwalten (Hinzufügen, Löschen, Ändern). Sobald Material gebucht wird, darf dieses für andere
Events nicht mehr zur Verfügung stehen. Wird ein Mitarbeiter einem Event zugeordnet, muss
die Verfügbarkeit der Mitarbeiter zum Zeitpunkt des Events beachtet werden (Urlaub / Einsatz
bei einem anderen Event / Krankheit). Mitarbeiter werden automatisch informiert, sobald diese
in  einem  Event  eingeplant  werden,  sodass  diese  Mitarbeiter  einen  aktuellen  Zeit-  bzw.
Arbeitsplan  haben,  die  den  Mitarbeitern  vom  Softwareprodukt  angezeigt  werden.  Für
Mitarbeiter soll der Qualifizierungsgrad (Fachkraft / Meister / Aushilfskraft), das Fachgebiet
(Licht  /  Ton  /  Medientechnik  /  Bühnenbau  /  etc.)  und  die  Führerscheinklasse  gespeichert
werden.  Material  kann  verschiedene  Eigenschaften  (verfügbare  Anzahl,  Leistungsaufnahme,
Lagermaße,  Lagergewicht,  Fluggewicht,  Anschaffungspreis,  Verleihpreis,  Anzahl  der
Verleihungen,  Wartungszyklus,  letzte  Wartung,  Kategorie,  Bild).  Material  kann  kategorisiert
(Ton / Licht / Bühnenbau / Catering / etc.) zugeordnet werden. Die Kategorien sollen um neue
Kategorien erweitert werden können. Kategorien sollen gelöscht werden können. Ebenfalls wird
für das Material der veränderbare Lagerstandort zugeordnet. Damit später auffallende Schäden
an einem Material noch einem Veranstalter und der entsprechenden Versicherung zugeordnet
werden  kann,  muss  für  das  Material  auch  die  Verleih-Historie  gespeichert  und  angezeigt
werden.  Das  Softwareprodukt  muss  einen  Hinweis  geben,  wenn  auf  Grundlage  eines
Wartungszyklus ein bestimmtes Material gewartet bzw. geprüft werden muss. Ebenfalls muss
die  Software  anzeigen,  welche  Geräte  sich  bereits  amortisiert  haben.  Grundlage  für  die
Amortisationsrechnung sind die Anschaffungskosten, die Verleihkosten und die Anzahl, wie oft
ein Gerät bereits verliehen wurde. Zu jedem Material muss abgespeichert werden können, wie
weit die Amortisierung fortgeschritten ist. Wird nachträglich der Verleihpreis des Materials
verändert,  darf  die  bisher  errechnete  Amortisierung  nicht  angepasst  werden.  Wird  der
Einkaufspreis des Materials geändert, hat dies jedoch Einfluss auf die Amortisierung. Nach
Ende der Veranstaltung kann eine Rechnung erzeugt und zugestellt werden. Diese Rechnung
muss folgendes beinhalten: Rechnungsbetrag (Brutto / Netto / Rabatt), Mitarbeiter und deren
Lohnkosten, Materialkosten, Fahrkosten, Verwaltungskosten, Kunde / Veranstalter, Datum und
Dauer,  Ort,  Verfasser  des  Angebots,  Materialliste,  Rechnungsfrist,  Rechnungsnummer,
Kontodaten des Unternehmens. Veranstaltungen sollen als bezahlt markiert werden können.
Bezahlte  und  nicht  bezahlte  Veranstaltungen  sollen  jeweils  in  einer  separaten  Darstellung
angezeigt und gefiltert werden. Die Software soll nach einem gewissen Zeitraum (üblicherweise
30 Tage) daran erinnern, dass Rechnungen noch nicht bezahlt worden sind. Aus einer nicht
bezahlten  Rechnung  soll  eine  Mahnung  mit  Mahngebühr  und  neuem  Zahlungszeitraum
generiert  werden  können.  Über  das  Softwareprodukt  werden  sehr  vertrauliche
Kontaktinformationen sowie Nachrichten ausgetauscht, die unter keinen Umständen von nicht
autorisierten Parteien einsehbar sein dürfen. Daten müssen daher verschlüsselt gespeichert und
ausgetauscht werden. Das Softwareprodukt muss die Nutzerdaten gemäß Datenschutzrichtlinie
(DSGVO) behandeln. Die Datenschutzrichtlinie muss von den Nutzern bestätigt werden, bevor
diese  das  Softwareprodukt  vollständig  nutzen  können.  Die  Speicherung  von  privaten
Informationen, insbesondere Kontaktinformationen, darf nicht in falsche Hände geraten. Die
Daten  sollen  daher  besonders  verschlüsselt  unter  den  Nutzern  versendet  und  gespeichert
werden.  Selbst  der  Betreiber  des  Softwareprodukts  soll  diese  Informationen  nicht  einsehen
können.  Vielleicht  ist  ein  Ende-zu-Ende  Verschlüsselungssystem  zu  verwenden,  bei  dem
Schlüssel erst ausgetauscht werden, wenn Erlaubnis dazu erteilt wurde. Um zu verhindern, dass
Unbefugte Nutzer-Accounts übernehmen können, werden Nutzer ermutigt, starke Passwörter
zu verwenden und eine 2FA-Authentifizierung per SMS oder vergleichbares für die Anmeldung
zu  verwenden.  Accounts  könnten  auch  an  gültige  Telefonnummern  gebunden  werden,  um
Missbrauch zu verhindern. Daten werden generell über das https-Protokoll ausgetauscht.
