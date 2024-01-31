CREATE TABLE customers (
    customer_id int PRIMARY KEY,
	customer_firstname varchar (255),
	customer_surname varchar (255),
	customer_address varchar (255),
	customer_city varchar (255),
	customer_email varchar (255),
	customer_phone varchar (255),
	customer_balance int
);

CREATE TABLE orders (
	order_id int PRIMARY KEY,
	customer_id int,
	wine_quantity int,
	tanic_level int,
	wine_name varchar (255),
	created_at TIMESTAMP,
	last_update DATETIME NOT NULL,
);