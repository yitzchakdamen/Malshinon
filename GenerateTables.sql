
    CREATE TABLE IF NOT EXISTS people 
    (
        id INT AUTO_INCREMENT PRIMARY KEY,
        first_name VARCHAR(30),
        last_name VARCHAR(30),
        secret_code VARCHAR(30) UNIQUE
    );

    CREATE TABLE IF NOT EXISTS intel_reports 
    (
        id INT AUTO_INCREMENT PRIMARY KEY,
        reporter_id INT,
        target_id INT,
        text TEXT,
        timestamp DATETIME DEFAULT NOW(),
        
        FOREIGN KEY (reporter_id) REFERENCES people(id),
        FOREIGN KEY (target_id) REFERENCES people(id)
    );


    CREATE TABLE IF NOT EXISTS  notifications
    (
        id INT AUTO_INCREMENT PRIMARY KEY,
        target_id INT,
        Reason TEXT,
        timestamp DATETIME DEFAULT NOW(),
        
        FOREIGN KEY (target_id) REFERENCES people(id)
    );

    CREATE TABLE IF NOT EXISTS people_status 
    (
        people_id INT PRIMARY KEY,
        num_reports INT DEFAULT 0,
        num_mentions INT DEFAULT 0,
        reporter BOOLEAN DEFAULT 0, 
        target BOOLEAN DEFAULT 0,
        potential_agent INT DEFAULT 0,
        target_risk INT DEFAULT 0,
    
        FOREIGN KEY (people_id) REFERENCES people(id)
    );



-- הכנסת אנשים לטבלת people
INSERT INTO people (first_name, last_name, secret_code) VALUES
('איתן', 'כהן', 'AGENT-X987'),
('מיה', 'לוי', 'SHADOW-555'),
('נועם', 'פרץ', 'PHANTOM-42'),
('תמר', 'מזרחי', 'RAVEN-007'),
('אריאל', 'ברק', 'FALCON-33'),
('ליאור', 'גולן', 'SPECTER-11'),
('יעל', 'דוד', 'NIGHT-789'),
('דניאל', 'אשכנזי', 'SILENT-654'),
('שרה', 'הראל', 'STAR-321'),
('אלכס', 'שטיין', 'GHOST-159');

-- הכנסת דיווחי מודיעין לטבלת intel_reports
INSERT INTO intel_reports (reporter_id, target_id, text) VALUES
(1, 3, 'נועם פרץ נצפה מתעד תחנת רכבת מרכזית בשעה 03:00. התנהגות חשודה.'),
(2, 4, 'תמר מזרחי ביקשה מידע רגיש תחת תואנה של מחקר אקדמי.'),
(5, 3, 'נועם פרץ יצר קשר עם גורם מוכר ברשימת המעקב שלנו.'),
(3, 7, 'יעל דוד נצפתה לוקחת תמונות של מתקן צבאי סגור.'),
(6, 1, 'איתן כהן קיבל חבילה לא מזוהה משליח לא מוכר.'),
(4, 5, 'אריאל ברק ניסה לגשת למערכות מחשב ללא הרשאות מתאימות.'),
(7, 2, 'מיה לוי נצפתה בפגישה עם אדם המזוהה כסוכן זר.'),
(8, 10, 'אלכס שטיין העביר מידע רגיש דרך ערוץ לא מאובטח.'),
(9, 6, 'ליאור גולן השתמש בציוד האזנה ללא אישור.'),
(10, 9, 'שרה הראל מחקה קבצים חשובים מהמערכת.');

-- הכנסת התראות לטבלת notifications
INSERT INTO notifications (target_id, Reason) VALUES
(3, 'מספר דיווחים חריג על פעילות חשודה'),
(4, 'ניסיון גישה למידע רגיש'),
(7, 'צילום מתקנים מוגנים'),
(1, 'קבלת חבילה חשודה'),
(5, 'ניסיון גישה לא מורשית למערכות'),
(2, 'מגע עם סוכן זר'),
(10, 'העברת מידע רגיש בצורה לא מאובטחת'),
(6, 'שימוש בציוד ללא הרשאה'),
(9, 'מחיקת קבצים חשובים'),
(8, 'התנהגות לא עקבית עם פרופיל העבודה');

-- הכנסת סטטוסים לטבלת people_status
INSERT INTO people_status (people_id, num_reports, num_mentions, reporter, target, potential_agent, target_risk) VALUES
(1, 2, 1, 1, 1, 3, 2),
(2, 1, 1, 1, 1, 2, 3),
(3, 3, 2, 1, 1, 4, 4),
(4, 2, 1, 1, 1, 3, 3),
(5, 1, 1, 1, 1, 2, 2),
(6, 1, 1, 1, 1, 2, 3),
(7, 2, 1, 1, 1, 3, 3),
(8, 1, 1, 1, 1, 2, 2),
(9, 1, 1, 1, 1, 2, 3),
(10, 2, 1, 1, 1, 3, 4);