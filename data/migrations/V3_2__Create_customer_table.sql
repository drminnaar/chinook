CREATE TABLE sales.customer
(
    "customer_id" INT NOT NULL,
    "first_name" VARCHAR(40) NOT NULL,
    "last_name" VARCHAR(20) NOT NULL,
    "company" VARCHAR(80),
    "address" VARCHAR(70),
    "city" VARCHAR(40),
    "state" VARCHAR(40),
    "country" VARCHAR(40),
    "postal_code" VARCHAR(10),
    "phone" VARCHAR(24),
    "fax" VARCHAR(24),
    "email" VARCHAR(60) NOT NULL,
    "support_rep_id" INT,
    CONSTRAINT "pk_customer" PRIMARY KEY  ("customer_id")
);

ALTER TABLE sales.customer ADD CONSTRAINT "fk_customer_supportrepid"
    FOREIGN KEY ("support_rep_id") REFERENCES employee_operations.employee ("employee_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_customer_supportrepid" ON sales.customer ("support_rep_id");