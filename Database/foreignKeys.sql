alter table orders add constraint FK_customer_id
    foreign key (customer_id) REFERENCES  customers(customer_id);
