use Lab3;

CREATE TABLE School(
SchoolID int NOT NULL Primary KEY,
SchoolName varchar(255) NOT NULL,
PhoneNumber varchar(255) NOT NULL,
ContactName varchar(255) NOT NULL,
SchoolAddress varchar(255) NOT NULL,
City varchar(255) NOT NULL,
State varchar(255) NOT NULL,
Zipcode varchar(255) NOT NULL,
);

CREATE TABLE Event(
EventID int NOT NULL PRIMARY KEY,
EventName varchar(255) NOT NULL,
CalendarDate varchar(255) NOT NULL,
TimeOfDay varchar(255) NOT NULL,
RoomNumber varchar(255) NOT NULL
);

CREATE TABLE Tshirt(
TshirtID int NOT NULL PRIMARY KEY,
Size varchar(255) NOT NULL,
Color varchar(255) NOT NULL
);

CREATE TABLE Teacher(
TeacherID int NOT NULL PRIMARY KEY,
FirstName varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
PhoneNumber varchar(255) NOT NULL,
EmailAddress varchar(255) NOT NULL,
Grade int NOT NULL,
SchoolID int FOREIGN KEY REFERENCES School(SchoolID),
);


CREATE TABLE TeacherEvent(
TeacherEventID int NOT NULL PRIMARY KEY,
TeacherID int FOREIGN KEY REFERENCES Teacher(TeacherID),
EventID int FOREIGN KEY REFERENCES Event(EventID)
);

CREATE TABLE Student(
StudentID int NOT NULL PRIMARY KEY,
FirstName varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
Age varchar(255) NOT NULL,
Notes varchar(255) NOT NULL,
TeacherID int FOREIGN KEY REFERENCES Teacher(TeacherID),
TshirtID int FOREIGN KEY REFERENCES Tshirt(TShirtID)
);

CREATE TABLE StudentEvent(
StudentEventID int NOT NULL PRIMARY KEY,
StudentID int FOREIGN KEY REFERENCES Student(StudentID),
EventID int FOREIGN KEY REFERENCES Event(EventID)
);

CREATE TABLE Coordinator(
CoordinatorID int NOT NULL PRIMARY KEY,
FirstName varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
Phonenumber varchar(255) NOT NULL,
Email varchar(255) NOT NULL, 
TshirtID int FOREIGN KEY REFERENCES Tshirt(TshirtID)
);

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[File](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](200) NULL,
	[FileSize] [int] NOT NULL,
	[ContentType] [varchar](200) NOT NULL,
	[FileExtension] [varchar](10) NOT NULL,
	[FileContent] [varbinary](MAX) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE CoordinatorEvent(
CoordinatorEventID int NOT NULL PRIMARY KEY,
CoordinatorID int FOREIGN KEY REFERENCES Coordinator(CoordinatorID),
EventID int FOREIGN KEY REFERENCES Event(EventID)
);

CREATE TABLE Volunteer(
VolunteerID int NOT NULL PRIMARY KEY,
FirstName varchar(255) NOT NULL,
LastName varchar(255) NOT NULL,
Phonenumber varchar(255) NOT NULL,
Email varchar(255) NOT NULL,
TshirtID int FOREIGN KEY REFERENCES Tshirt(TshirtID)
);


CREATE TABLE VolunteerEvent(
VolunteerEventID int NOT NULL PRIMARY KEY,
VolunteerID int FOREIGN KEY REFERENCES Volunteer(VolunteerID),
EventID int FOREIGN  KEY REFERENCES Event(EventID)
);

CREATE TABLE Attendance(
AttendanceID int NOT NULL PRIMARY KEY,
StudentID int FOREIGN KEY REFERENCES Student(StudentID),
EventID int FOREIGN KEY REFERENCES Event(EventID)
);

INSERT INTO Tshirt(TshirtID,Size,Color) VALUES (135,'Large', 'Yellow');
INSERT INTO Tshirt(TshirtID,Size,Color)  VALUES (456,'Medium', 'Red');
INSERT INTO Tshirt(TshirtID,Size,Color)  VALUES (876,'Small', 'Blue');
INSERT INTO Tshirt(TshirtID,Size,Color)  VALUES (787,'Small','Green');
Select * from Tshirt;

INSERT INTO School(SchoolID,SchoolName,PhoneNumber,ContactName,SchoolAddress,City,State,Zipcode) VALUES (4323,'Cub Run Middle School', '703-222-9343','Randy Jackson', '14530 Creek Branch Court','Harrisonburg', 'VA','22801')
INSERT INTO School(SchoolID,SchoolName,PhoneNumber,ContactName,SchoolAddress,City,State,Zipcode)  VALUES (4343,'Westfield Middle School', '703-343-3423','Mila Kunis', '1141 Devon Lane','Harrisonburg', 'VA','22801')
INSERT INTO School(SchoolID,SchoolName,PhoneNumber,ContactName,SchoolAddress,City,State,Zipcode)  VALUES (4342,'Trinity Middle School', '703-336-0000','Miley Cyrus', '1234 Windy Lane','Harrisonburg', 'VA','22801')
Select * from School;

INSERT INTO Event(EventID,EventName,CalendarDate,TimeOfDay,RoomNumber) VALUES(1111,'Wiffle Ball','09/03/2020','1:00pm','100');
INSERT INTO Event(EventID,EventName,CalendarDate,TimeOfDay,RoomNumber) VALUES(2222,'Corn Hole','09/03/2020','2:00pm','200');
INSERT INTO Event(EventID,EventName,CalendarDate,TimeOfDay,RoomNumber) VALUES(3333,'Painting','09/03/2020','3:00pm','300');
INSERT INTO Event(EventID,EventName,CalendarDate,TimeOfDay,RoomNumber) VALUES(4444,'Soccer','09/03/2020','4:00pm','430'); 
Select * From Event;

INSERT INTO Coordinator(CoordinatorID,FirstName,LastName,PhoneNumber,Email,TshirtID) VALUES (1132421,'Lea','Ricci','234-545-6533','riccilea@hotmail.com','135');
INSERT INTO Coordinator(CoordinatorID,FirstName,LastName,PhoneNumber,Email,TshirtID) VALUES (1133552,'Niamh','Nelson','943-432-9854','nelsonniamh@gmail.com','456');
INSERT INTO Coordinator(CoordinatorID,FirstName,LastName,PhoneNumber,Email,TshirtID) VALUES (1114532,'Heather','Ren','703-937-8233','hren@gmail.com','787');
Select * From Coordinator; 

INSERT INTO CoordinatorEvent(CoordinatorEventID,CoordinatorID,EventID) VALUES(1888,'1114532','1111') 
INSERT INTO CoordinatorEvent(CoordinatorEventID,CoordinatorID,EventID) VALUES(2999,'1132421','2222') 
INSERT INTO CoordinatorEvent(CoordinatorEventID,CoordinatorID,EventID) VALUES(3000,'1133552','3333') 
Select * From CoordinatorEvent;

INSERT INTO Teacher (TeacherId,FirstName,LastName,PhoneNumber,EmailAddress,Grade,SchoolID) VALUES (1113212,'John', 'Miller', 454-555-2222, 'johnm@gmail.com',5, 4323)
INSERT INTO Teacher (TeacherId,FirstName,LastName,PhoneNumber,EmailAddress,Grade,SchoolID) VALUES (113422,'Mike', 'Smith', 326-884-9652, 'mikeS@gmail.com',5, 4343)
INSERT INTO Teacher (TeacherId,FirstName,LastName,PhoneNumber,EmailAddress,Grade,SchoolID) VALUES (153212,'Brian', 'Howard', 441-751-9366, 'BrianH@gmail.com',6, 4342)
INSERT INTO Teacher (TeacherId,FirstName,LastName,PhoneNumber,EmailAddress,Grade,SchoolID) VALUES (153213,'Jeremy', 'Ezell', 441-751-9366, 'BrianH@gmail.com',6, 4342)
Select * From Teacher;

INSERT Student(StudentID,FirstName,LastName,Age,Notes,TeacherID,TshirtID) VALUES (10232233,'Anu', 'Rawat', '12', 'n/a','1113212','135');
INSERT Student(StudentID,FirstName,LastName,Age,Notes,TeacherID,TshirtID) VALUES (10938478,'JIm','Jones','10','n/a','113422','456');
INSERT Student(StudentID,FirstName,LastName,Age,Notes,TeacherID,TshirtID) VALUES (23843938,'Torri','Kroh','11','n/a','153212','876');
INSERT Student(StudentID,FirstName,LastName,Age,Notes,TeacherID,TshirtID) VALUES (34243243,'Jacob','Smith','12','n/a','153212','787');
SELECT * FROM Student;

  INSERT TeacherEvent(TeacherEventID,TeacherID,EventID) VALUES (1000,'113422','1111');
  INSERT TeacherEvent(TeacherEventID,TeacherID,EventID) VALUES (2000,'153212','2222');
  INSERT TeacherEvent(TeacherEventID,TeacherID,EventID) VALUES (3000,'153212','3333');
  SELECT * from TeacherEvent;

  INSERT StudentEvent(StudentEventID,StudentID,EventID) VALUES (1000,'10232233','1111');
  INSERT StudentEvent(StudentEventID,StudentID,EventID) VALUES (1001,'10232233','2222');
  INSERT StudentEvent(StudentEventID,StudentID,EventID) VALUES (1002,'10232233','3333');
  INSERT StudentEvent(StudentEventID,StudentID,EventID) VALUES (1003,'23843938','1111');
  INSERT StudentEvent(StudentEventID,StudentID,EventID) VALUES (1004,'23843938','2222');
  INSERT StudentEvent(StudentEventID,StudentID,EventID) VALUES (1005,'23843938','3333');
  SELECT * from StudentEvent;

INSERT Volunteer(VolunteerID,FirstName,LastName,Phonenumber,Email,TshirtID) VALUES (111,'Ester','Jon','571-234-5325','ejon@hotmail.com','876');
INSERT Volunteer(VolunteerID,FirstName,LastName,Phonenumber,Email,TshirtID) VALUES (222,'Natalie','Roberts','703-094-2321','roberts@gmail.com','787');
INSERT Volunteer(VolunteerID,FirstName,LastName,Phonenumber,Email,TshirtID) VALUES (598,'William','Vince','342-343-3433','vince@gmail.com','135');
SELECT * FROM Volunteer;

  INSERT VolunteerEvent(VolunteerEventID,VolunteerID,EventID) VALUES (9432,'111','4444');
  INSERT VolunteerEvent(VolunteerEventID,VolunteerID,EventID) VALUES (4324,'222','2222');
  INSERT VolunteerEvent(VolunteerEventID,VolunteerID,EventID) VALUES (9123,'598','1111');
  SELECT * from TeacherEvent;