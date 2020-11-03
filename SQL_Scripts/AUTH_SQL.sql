use AUTH;

CREATE TABLE Account(
AccountID int NOT NULL Primary KEY,
AccountType varchar(255) NOT NULL,
AccountTypeID int NOT NULL,
UserName varchar(255) NOT NULL,
PassWord varchar(255) NOT NULL,
Salt varchar(225) NOT NULL
);

INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (1,'Coordinator',1132421,'riccile','B+y1E6/VpTZ3MTFASu99WeaawJVE58AtZGMGuTOloGo=','bqPyIwjgx8eVJO+7XU+hkQ==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (2,'Coordinator',1133552,'niamnNel','CoDmakmK2pzYjqsAPfFQTcYxjL0vvIAJUSfTkAKcL/k=','ndcC6Hnm97Zx6uo47vibQg==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (3,'Coordinator',1114532,'renheat','fnmhZcbF1PjcCflm25qZVVS2lg+Z/IeyN68aesBiawg=','f9f4xbasEJXxQLtQabLXRw==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (4,'Teacher',1113212,'john444','sHrObtQqmeQJg3ST57YiWgeHwVq/gzgw4qhJ3Bn1SnU=','MkEXudtm//0u4DOuiBExKA==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (5,'Teacher',113422,'Mike22','gyzAngnlfh7VbXGbIJuh52bvPHiD/8l8zs4DzD2Rgdc=','yavyl6/YU4nqs4IhBOVySQ==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (6,'Teacher',153212,'BrianH','dzxt0ZTBkhM9JO6yno+97EZ1T3p3jBzogR5xL/SvRXM=','CBZagc+yBcgUqRoCZSSdjw==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (7,'Teacher',153213,'Java23','UHyUDzX/HhZg+kqpuB8ZR4/G1TKpcd1am39asZcXnxA=','edUP5w2jH+zl5pkJkIURzQ==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (8,'Volunteer',111,'jonax','n2cO5Lc9jogKPS/CWMQEhkEBJtAVnPU6Kn59YZcqzlg=','Af/uJOL3ySQN2Njxz1jD1Q==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (9,'Volunteer',222,'robnat','H7/0o2bSM1ezQugOveJbRHV1jX7P5bVJzPO+k44ARTs=','q6QHHuhR3Dmevi9bnelkXQ==');
INSERT INTO Account(AccountID,AccountType,AccountTypeID,UserName,PassWord,Salt) VALUES (10,'Volunteer',598,'willieboy','nes06rozmilGr7xgKvNJDSHvDXy5CUTJ62UiUjJYtqM=','3n2v/Ho2dnSxlbxpafeF0g==');