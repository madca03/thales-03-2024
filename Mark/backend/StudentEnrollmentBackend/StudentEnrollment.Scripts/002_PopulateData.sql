SET IDENTITY_INSERT [dbo].[Course] ON;

INSERT INTO [dbo].[Course] (Id, Name, Description, StartDate, EndDate, Fees, LocationAddress, ContactPerson)
VALUES
    (1, 'Introduction to Data Science', 'Basic concepts of data science', '2024-11-01', '2024-11-15', 500.0, '123 Data St, Cityville', 'Alice Johnson'),
    (2, 'Advanced SQL Programming', 'In-depth SQL training', '2024-11-05', '2024-12-05', 800.0, '456 SQL Ln, Dataville', 'Bob Smith'),
    (3, 'Machine Learning 101', 'Introduction to machine learning', '2024-12-01', '2024-12-15', 700.0, '789 ML Rd, TechCity', 'Carol White'),
    (4, 'Full Stack Web Development', 'Learn full stack web development', '2024-12-10', '2025-01-20', 1200.0, '101 Web Ave, Devtown', 'Dave Brown'),
    (5, 'Cybersecurity Basics', 'Fundamentals of cybersecurity', '2024-12-15', '2025-01-15', 600.0, '202 Secure Blvd, Cybercity', 'Eve Black'),
    (6, 'Cloud Computing', 'Introduction to cloud services', '2025-01-01', '2025-01-30', 750.0, '303 Cloud St, SkyCity', 'Frank Blue'),
    (7, 'Python for Beginners', 'Learn Python programming', '2024-11-10', '2024-11-30', 450.0, '404 Python Ln, Codeville', 'Grace Green'),
    (8, 'Digital Marketing Essentials', 'Basics of digital marketing', '2024-11-15', '2024-12-10', 500.0, '505 Market Rd, Adtown', 'Henry Red'),
    (9, 'Project Management', 'Project management skills', '2025-01-05', '2025-02-05', 900.0, '606 Manage St, BizCity', 'Ivy Gray'),
    (10, 'Graphic Design Fundamentals', 'Learn graphic design basics', '2024-12-20', '2025-01-25', 650.0, '707 Design Ave, Artville', 'Jack Orange'),
    (11, 'Artificial Intelligence Overview', 'Intro to AI concepts', '2025-02-01', '2025-02-28', 1000.0, '808 AI Rd, BrainCity', 'Karen Violet'),
    (12, 'Big Data Analytics', 'Analyze big data with modern tools', '2025-01-10', '2025-02-10', 1100.0, '909 Data Blvd, Dataville', 'Leo Indigo'),
    (13, 'React for Beginners', 'Introduction to React', '2024-12-01', '2024-12-20', 550.0, '1010 JS Ave, WebCity', 'Mona Yellow'),
    (14, 'Statistics for Data Science', 'Basic statistics for data science', '2025-01-15', '2025-02-15', 600.0, '1111 Stats St, Numtown', 'Nate Pink'),
    (15, 'Blockchain Technology', 'Learn blockchain fundamentals', '2025-02-10', '2025-03-10', 1200.0, '1212 Crypto Blvd, CoinCity', 'Olive Maroon'),
    (16, 'Ethical Hacking', 'Introduction to ethical hacking', '2024-11-20', '2024-12-15', 950.0, '1313 Hack St, Cyberville', 'Pat Silver'),
    (17, 'Creative Writing', 'Develop creative writing skills', '2024-11-25', '2024-12-10', 400.0, '1414 Write Rd, Storyville', 'Quinn Gold'),
    (18, 'Data Visualization with Python', 'Visualize data using Python', '2024-12-05', '2025-01-05', 700.0, '1515 Viz Blvd, GraphCity', 'Rex Purple'),
    (19, 'Public Speaking Mastery', 'Master public speaking skills', '2025-01-20', '2025-02-20', 550.0, '1616 Speak Ave, Talktown', 'Sue Teal'),
    (20, 'Introduction to Java', 'Learn Java programming basics', '2025-01-25', '2025-02-25', 480.0, '1717 Java St, Codeville', 'Tom Brown');

SET IDENTITY_INSERT [dbo].[Course] OFF;
GO

-------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT [dbo].[Student] ON;

INSERT INTO [dbo].[Student] (Id, Name, BirthDate, Phone, Email, Gender, Address)
VALUES
    (1, 'John Doe', '2000-05-15', '1234567890', 'johndoe1@example.com', 'Male', '123 Main St, Cityville'),
    (2, 'Jane Smith', '1999-08-20', '0987654321', 'janesmith1@example.com', 'Female', '456 Elm St, Townville'),
    (3, 'Alice Johnson', '2001-02-10', '2345678901', 'alice.johnson@example.com', 'Female', '789 Oak St, Villagetown'),
    (4, 'Bob Brown', '1998-11-25', '3456789012', 'bobbrown@example.com', 'Male', '321 Maple Ave, Smalltown'),
    (5, 'Charlie Green', '2000-07-30', '4567890123', 'charlie.green@example.com', 'Male', '654 Cedar Blvd, Bigcity'),
    (6, 'Diana White', '1997-03-12', '5678901234', 'diana.white@example.com', 'Female', '987 Birch Rd, Oldtown'),
    (7, 'Ethan Black', '2002-09-17', '6789012345', 'ethan.black@example.com', 'Male', '101 Pine St, Midtown'),
    (8, 'Fiona Red', '2000-12-05', '7890123456', 'fiona.red@example.com', 'Female', '202 Spruce Ave, Downtown'),
    (9, 'George Blue', '1999-01-08', '8901234567', 'george.blue@example.com', 'Male', '303 Willow Ln, Eastside'),
    (10, 'Hannah Yellow', '2001-06-19', '9012345678', 'hannah.yellow@example.com', 'Female', '404 Chestnut Rd, Westville'),
    (11, 'Isaac Gray', '2000-03-25', '1234567891', 'isaac.gray@example.com', 'Male', '505 Walnut St, Southtown'),
    (12, 'Julia Pink', '1998-10-11', '2345678912', 'julia.pink@example.com', 'Female', '606 Ash Rd, Northtown'),
    (13, 'Kevin Orange', '1997-08-05', '3456789123', 'kevin.orange@example.com', 'Male', '707 Poplar St, Oldcity'),
    (14, 'Lara Purple', '2002-04-22', '4567891234', 'lara.purple@example.com', 'Female', '808 Cedar St, Hilltown'),
    (15, 'Mike White', '1998-07-15', '5678912345', 'mike.white@example.com', 'Male', '909 Fir Ln, Citytown'),
    (16, 'Nina Gold', '2001-05-10', '6789123456', 'nina.gold@example.com', 'Female', '1010 Oak St, Beachside'),
    (17, 'Oscar Silver', '1999-12-01', '7891234567', 'oscar.silver@example.com', 'Male', '1111 Maple St, Seaside'),
    (18, 'Paula Teal', '1997-06-07', '8901234568', 'paula.teal@example.com', 'Female', '1212 Elm St, Riverside'),
    (19, 'Quinn Indigo', '2000-02-28', '9012345679', 'quinn.indigo@example.com', 'Male', '1313 Birch Rd, Lakeview'),
    (20, 'Rachel Green', '1998-11-30', '1023456789', 'rachel.green@example.com', 'Female', '1414 Spruce St, Valleytown'),
    (21, 'Sam Brown', '1997-07-24', '2134567890', 'sam.brown@example.com', 'Male', '1515 Willow Ln, Uptown'),
    (22, 'Tina Black', '2001-09-17', '3245678901', 'tina.black@example.com', 'Female', '1616 Pine Ave, Sidetown'),
    (23, 'Umar Blue', '2000-10-22', '4356789012', 'umar.blue@example.com', 'Male', '1717 Cedar Rd, Backtown'),
    (24, 'Vera White', '1999-04-04', '5467890123', 'vera.white@example.com', 'Female', '1818 Fir Blvd, Fronttown'),
    (25, 'Zane Violet', '2002-03-03', '6789012345', 'zane.violet@example.com', 'Male', '2222 Chestnut St, Riverbend');

SET IDENTITY_INSERT [dbo].[Student] OFF;