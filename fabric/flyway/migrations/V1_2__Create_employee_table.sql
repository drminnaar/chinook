CREATE TABLE operations.employee
(
    "employee_id" INT NOT NULL,
    "created_date" TIMESTAMPTZ NOT NULL,
    "updated_date" TIMESTAMPTZ NOT NULL,
    "last_name" TEXT NOT NULL,
    "first_name" TEXT NOT NULL,
    "title" TEXT,
    "reports_to" INT,
    "birth_date" TIMESTAMP,
    "hire_date" TIMESTAMP,
    "address" TEXT,
    "city" TEXT,
    "state" TEXT,
    "country" TEXT,
    "postal_code" TEXT,
    "phone" TEXT,
    "fax" TEXT,
    "email" TEXT,
    CONSTRAINT "pk_operations_employee_employeeid" PRIMARY KEY ("employee_id")
);

-- define foreign keys
ALTER TABLE operations.employee ADD CONSTRAINT "fk_operations_employee_reportsto"
    FOREIGN KEY ("reports_to") REFERENCES operations.employee ("employee_id") ON DELETE NO ACTION ON UPDATE NO ACTION;

CREATE INDEX "ifk_operations_employee_reportsto" ON operations.employee ("reports_to");

-- define indexes
CREATE UNIQUE INDEX "ux_operations_employee_email" ON operations.employee ("email");
CREATE UNIQUE INDEX "ux_operations_employee_lemail" ON operations.employee (lower("email"));