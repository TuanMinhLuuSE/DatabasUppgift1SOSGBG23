CREATE DATABASE IF NOT EXISTS bankdb;

USE bankdb;

CREATE TABLE rental_account(
	renter_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
	username VARCHAR(255),
	password VARCHAR(255)
);

CREATE TABLE renter_info(
	info_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
	firstname VARCHAR(255),
	lastname VARCHAR(255),
	address VARCHAR(255),
	zipcode INT,
	city VARCHAR(255),
	country VARCHAR(255),
	email VARCHAR(320),
	user_id INT,
	FOREIGN KEY (renter_id) REFERENCES rental_account(renter_id)
);

CREATE TABLE cars(
	car_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    car_brand VARCHAR(255),
    car_model VARCHAR(255),
    car_fueltype VARCHAR(255),
    car_numberofseats INT,
    car_available BOOL
);
    
CREATE TABLE rented_cars(
    rental_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    renter_id INT,
    car_id INT,
    FOREIGN KEY (renter_id) REFERENCES rental_account(renter_id),
    FOREIGN KEY (car_id) REFERENCES cars(car_id)
);
    
INSERT INTO cars VALUES(
	DEFAULT, "Volvo", "XC60", "SUV", "Hybrid, petrol", 5, TRUE,
	DEFAULT, "Mercedes-Benz", "E-class", "Sedan", "Diesel", 5, TRUE,
	DEFAULT, "Polestar", "Polestar 2", "Hatchback", "Electric", 5, TRUE,
	DEFAULT, "BMW", "X7", "SUV", "Petrol", 7, TRUE,
	DEFAULT, "Volkswagen", "ID.3", "Hatchback", "Electric", 5, TRUE,
	DEFAULT, "Volvo", "V90", "Wagon", "Diesel", 5, TRUE,
	DEFAULT, "BMW", "M4", "Coupe", "Petrol", 2, TRUE,
	DEFAULT, "Toyota", "Yaris", "Hatchback", "Petrol", 4, TRUE
);