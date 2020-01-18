CREATE TABLE sales.invoice
(
    "invoice_id" INT NOT NULL,
    "customer_id" INT NOT NULL,
    "invoice_date" TIMESTAMP NOT NULL,
    "billing_address" VARCHAR(70),
    "billing_city" VARCHAR(40),
    "billing_state" VARCHAR(40),
    "billing_country" VARCHAR(40),
    "billing_postal_code" VARCHAR(10),
    "total" NUMERIC(10,2) NOT NULL,
    CONSTRAINT "pk_invoice" PRIMARY KEY  ("invoice_id")
);

ALTER TABLE sales.invoice ADD CONSTRAINT "fk_invoice_customerid"
    FOREIGN KEY ("customer_id") REFERENCES sales.customer ("customer_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_invoice_customerid" ON sales.invoice ("customer_id");