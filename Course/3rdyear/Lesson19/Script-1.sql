CREATE TABLE IF NOT EXISTS Reservations (
    id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    room_id INT NOT NULL,
    start_date TIMESTAMP NOT NULL,
    end_date TIMESTAMP NOT NULL,
    price INT NOT NULL, 
    total INT NOT NULL
);

CREATE TABLE IF NOT EXISTS Rooms (
    id SERIAL PRIMARY KEY,
    home_type VARCHAR NOT NULL, 
    address VARCHAR NOT NULL,    
    has_tv BOOLEAN DEFAULT FALSE,
    has_internet BOOLEAN DEFAULT FALSE,
    has_kitchen BOOLEAN DEFAULT FALSE,
    has_air_con BOOLEAN DEFAULT FALSE,
    owner_id INT,
    latitude FLOAT,
    longitude FLOAT
);

CREATE TABLE IF NOT EXISTS Users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    email_verified TIMESTAMP,
    password VARCHAR(255) NOT NULL,
    latitude FLOAT,
    phone_number VARCHAR(20)
);

CREATE TABLE IF NOT EXISTS Reviews (
	id SERIAL PRIMARY KEY,
	reservation_id INT, 
	rating INT
);







