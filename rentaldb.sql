CREATE DATABASE IF NOT EXISTS rentaldb;

USE rentaldb;

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
	renter_id INT,
	FOREIGN KEY (renter_id) REFERENCES rental_account(renter_id)
);

CREATE TABLE cars(
	car_id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    car_brand VARCHAR(255),
    car_model VARCHAR(255),
    car_type VARCHAR(255),
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
    
INSERT INTO cars (car_id, car_brand, car_model, car_type, car_fueltype, car_numberofseats, car_available) 
VALUES
	(DEFAULT, "Volvo", "XC60", "SUV", "Hybrid, petrol", 5, TRUE),
	(DEFAULT, "Mercedes-Benz", "E-class", "Sedan", "Diesel", 5, TRUE),
	(DEFAULT, "Polestar", "Polestar 2", "Hatchback", "Electric", 5, TRUE),
	(DEFAULT, "BMW", "X7", "SUV", "Petrol", 7, TRUE),
	(DEFAULT, "Volkswagen", "ID.3", "Hatchback", "Electric", 5, TRUE),
	(DEFAULT, "Volvo", "V90", "Wagon", "Diesel", 5, TRUE),
	(DEFAULT, "BMW", "M4", "Coupe", "Petrol", 2, TRUE),
	(DEFAULT, "Toyota", "Yaris", "Hatchback", "Petrol", 4, TRUE),
    (DEFAULT, "Tesla", "Model 3", "Sedan", "Electric", 5, TRUE),
    (DEFAULT, "Audi", "A6", "Wagon", "Diesel", 5, TRUE),
    (DEFAULT, "Porsche", "911 Carrera 4S", "Cabriolet", "Petrol", 4, TRUE),
    (DEFAULT, "Mercedes-Benz", "AMG GT-R", "Coupe", "Petrol", 2, TRUE);

DELIMITER //
CREATE TRIGGER new_rental
AFTER INSERT ON rented_cars
FOR EACH ROW
BEGIN
	UPDATE cars
	SET car_available = FALSE
	WHERE car_id = NEW.car_id;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER return_rental
AFTER DELETE ON rented_cars
FOR EACH ROW
BEGIN
	UPDATE cars
    SET car_available = TRUE
    WHERE car_id = OLD.car_id;
END //
DELIMITER ;

DELIMITER //

CREATE PROCEDURE editUserInfo(
    IN p_firstname VARCHAR(255),
    IN p_lastname VARCHAR(255),
    IN p_address VARCHAR(255),
    IN p_zipcode INT,
    IN p_city VARCHAR(255),
    IN p_country VARCHAR(255),
    IN p_email VARCHAR(320),
    IN p_renter_id INT
)
BEGIN
    DECLARE existing_renter_id INT;

    SELECT renter_id INTO existing_renter_id FROM renter_info WHERE renter_id = p_renter_id LIMIT 1;

    IF existing_renter_id IS NOT NULL THEN
        UPDATE renter_info
        SET
            firstname = p_firstname,
            lastname = p_lastname,
            address = p_address,
            zipcode = p_zipcode,
            city = p_city,
            country = p_country,
            email = p_email
        WHERE renter_id = p_renter_id;
    ELSE
        INSERT INTO renter_info (firstname, lastname, address, zipcode, city, country, email, renter_id)
        VALUES (p_firstname, p_lastname, p_address, p_zipcode, p_city, p_country, p_email, p_renter_id);
    END IF;
END //

DELIMITER ;

DELIMITER //
CREATE PROCEDURE searching (IN p_searchtext VARCHAR(255))
BEGIN
	SELECT * 
    FROM cars 
    WHERE car_brand 
    LIKE CONCAT(p_searchtext, "%") OR car_model LIKE CONCAT(p_searchtext, "%");
END;
//
DELIMITER ;

CREATE VIEW availableCars AS
SELECT * FROM cars WHERE car_available = 1;