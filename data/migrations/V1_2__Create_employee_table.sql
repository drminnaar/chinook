CREATE TABLE employee_operations.employee
(
    "employee_id" INT NOT NULL,
    "last_name" VARCHAR(20) NOT NULL,
    "first_name" VARCHAR(20) NOT NULL,
    "title" VARCHAR(30),
    "reports_to" INT,
    "birth_date" TIMESTAMP,
    "hire_date" TIMESTAMP,
    "address" VARCHAR(70),
    "city" VARCHAR(40),
    "state" VARCHAR(40),
    "country" VARCHAR(40),
    "postal_code" VARCHAR(10),
    "phone" VARCHAR(24),
    "fax" VARCHAR(24),
    "email" VARCHAR(60),
    CONSTRAINT "pk_employee" PRIMARY KEY  ("employee_id")
);

ALTER TABLE employee_operations.employee ADD CONSTRAINT "fk_employee_reportsto"
    FOREIGN KEY ("reports_to") REFERENCES employee_operations.employee ("employee_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_employee_reportsto" ON employee_operations.employee ("reports_to");