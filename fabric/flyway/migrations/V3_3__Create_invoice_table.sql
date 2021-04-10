CREATE TABLE sales.invoice
(
    "invoice_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "customer_id" INT NOT NULL,
    "invoice_date" TIMESTAMP NOT NULL,
    "billing_address" TEXT,
    "billing_city" TEXT,
    "billing_state" TEXT,
    "billing_country" TEXT,
    "billing_postal_code" TEXT,
    "total" NUMERIC(10,2) NOT NULL,
    CONSTRAINT "pk_sales_invoice_invoiceid" PRIMARY KEY  ("invoice_id")
);

-- define customer relationship
ALTER TABLE sales.invoice ADD CONSTRAINT "fk_sales_invoice_customerid"
    FOREIGN KEY ("customer_id") REFERENCES sales.customer ("customer_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_sales_invoice_customerid" ON sales.invoice ("customer_id");