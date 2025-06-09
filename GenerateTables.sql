
CREATE TABLE IF NOT EXISTS people 
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(30),
    last_name VARCHAR(30),
    secret_code VARCHAR(30) UNIQUE,
    type ENUM ("reporter", "target", "both", "potential_agent"),
    num_reports INT DEFAULT 0,
    num_mentions INT DEFAULT 0
);

CREATE TABLE IF NOT EXISTS IntelReports 
(
    id INT AUTO_INCREMENT PRIMARY KEY,
    reporter_id INT,
    target_id INT,
    text TEXT,
    timestamp DATETIME DEFAULT NOW(),
    
    FOREIGN KEY (reporter_id) REFERENCES people(id),
    FOREIGN KEY (target_id) REFERENCES people(id)
);
