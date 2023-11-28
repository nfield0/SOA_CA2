
DROP TABLE IF EXISTS customer_invoice, plant, customer;
DROP DATABASE IF EXISTS plant_database;
CREATE DATABASE plant_database;
USE plant_database;

-- --------------------------------------------------------

--
-- Table structure for table "customer"
--

CREATE TABLE customer (
  customer_id int(11) NOT NULL PRIMARY KEY,
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
	plant_id int(11) NOT NULL PRIMARY KEY,
  plant_name varchar(255) NOT NULL,
  plant_type varchar(255) NOT NULL,
  plant_price float
  );

-- --------------------------------------------------------

--
-- Table structure for table "customer_invoice"
--

CREATE TABLE customer_invoice (
  customer_id int(11) NOT NULL,
  plant_id int(11) NOT NULL,
  date_time_purchased datetime NOT NULL,
  customer_delivery_address varchar(255) NOT NULL,
  quantity int(11) NOT NULL,
  FOREIGN KEY (plant_id) REFERENCES plant(plant_id),
  FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
) ;

-- Sample Insert Queries

Insert INTO customer VALUES (0,"John","Flint", "john12@gmail.com", "087-7891234"),
(1,"David","Ray", "dray@gmail.com",  "805-731242");

Insert INTO plant VALUES (0, "Aloe Vera", "Succulent", 4.99),
(1, "Wysteria", "Tree", 49.99),
(2, "Apple Tree", "Tree", 40),
(3, "Hosta", "Shrub", 15);

Insert INTO customer_invoice VALUES (0,2,"2023-11-27 12:30:08", "12 Church View Mews", 2),
(0,1,"2023-11-25 12:38:00","12 Church View Mews", 1),
(1,0,"2023-11-26 10:30:08","Keady, Co. Armagh",5);
