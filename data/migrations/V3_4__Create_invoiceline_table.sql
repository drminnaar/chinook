CREATE TABLE sales.invoice_line
(
    "invoice_line_id" INT NOT NULL,
    "invoice_id" INT NOT NULL,
    "track_id" INT NOT NULL,
    "unit_price" NUMERIC(10,2) NOT NULL,
    "quantity" INT NOT NULL,
    CONSTRAINT "pk_invoice_line" PRIMARY KEY  ("invoice_line_id")
);

ALTER TABLE sales.invoice_line ADD CONSTRAINT "fk_invoiceline_invoiceid"
    FOREIGN KEY ("invoice_id") REFERENCES sales.invoice ("invoice_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_invoiceline_invoiceid" ON sales.invoice_line ("invoice_id");

ALTER TABLE sales.invoice_line ADD CONSTRAINT "fk_invoiceline_trackid"
    FOREIGN KEY ("track_id") REFERENCES music_catalog.track ("track_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_invoiceline_trackid" ON sales.invoice_line ("track_id");