﻿
USE SOA_CA2_hosted_db
DROP TABLE IF EXISTS customer_invoice, plant, customer;

-- --------------------------------------------------------

--
-- Table structure for table "customer"
--

CREATE TABLE customer (
  customer_id int NOT NULL PRIMARY KEY Identity,
  first_name varchar(255) NOT NULL,
  last_name varchar(255) NOT NULL,
  email_address varchar(255) NOT NULL,
  phone_num varchar(50) NOT NULL
);

-- --------------------------------------------------------

--
-- Table structure for table "plant"
--

CREATE TABLE plant (
	plant_id int NOT NULL PRIMARY KEY Identity,
  plant_name varchar(255) NOT NULL,
  plant_type varchar(255) NOT NULL,
  plant_price float
  );

-- --------------------------------------------------------

--
-- Table structure for table "customer_invoice"
--

CREATE TABLE customer_invoice (
  customer_invoice_id int NOT NULL PRIMARY KEY Identity,
  customer_id int NOT NULL,
  plant_id int NOT NULL,
  date_time_purchased datetime NOT NULL,
  customer_delivery_address varchar(255) NOT NULL,
  quantity int NOT NULL,
  FOREIGN KEY (plant_id) REFERENCES plant(plant_id),
  FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
) ;

-- Sample Insert Queries

INSERT INTO customer VALUES
('John', 'Flint', 'john12@gmail.com', '087-7891234'),
('David', 'Ray', 'dray@gmail.com', '805-731242');

INSERT INTO plant VALUES
('Aloe Vera', 'Succulent', 4.99),
('Wysteria', 'Tree', 49.99),
('Apple Tree', 'Tree', 40),
('Hosta', 'Shrub', 15);

INSERT INTO customer_invoice (customer_id, plant_id, date_time_purchased, customer_delivery_address, quantity) VALUES
(1, 2, '2023-11-27 12:30:08', '12 Church View Mews', 2),
(1, 1, '2023-11-25 12:38:00', '12 Church View Mews', 1),
(2, 3, '2023-11-26 10:30:08', 'Keady, Co. Armagh', 5);



