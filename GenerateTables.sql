
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