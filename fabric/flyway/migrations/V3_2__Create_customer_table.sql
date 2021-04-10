CREATE TABLE sales.customer
(
    "customer_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "first_name" TEXT NOT NULL,
    "last_name" TEXT NOT NULL,
    "company" TEXT,
    "address" TEXT,
    "city" TEXT,
    "state" TEXT,
    "country" TEXT,
    "postal_code" TEXT,
    "phone" TEXT,
    "fax" TEXT,
    "email" TEXT NOT NULL,
    "support_rep_id" INT,
    CONSTRAINT "pk_sales_customer_customerid" PRIMARY KEY ("customer_id")
);

-- define employee/sales-rep relationship
ALTER TABLE sales.customer ADD CONSTRAINT "fk_sales_customer_supportrepid"
    FOREIGN KEY ("support_rep_id") REFERENCES operations.employee ("employee_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_sales_customer_supportrepid" ON sales.customer ("support_rep_id");