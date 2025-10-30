-- SQL script per creare il database MySQL e la tabella task
-- Esegui questo script nel tuo MySQL server

-- Crea il database (se non esiste già)
CREATE DATABASE IF NOT EXISTS todo_db;

-- Usa il database
USE todo_db;

-- Crea la tabella task
CREATE TABLE IF NOT EXISTS task (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description TEXT,
    completed BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- Inserisci alcuni dati di esempio (opzionale)
INSERT INTO task (title, description, completed) VALUES 
('Imparare Unity', 'Studiare i fondamentali di Unity e C#', false),
('Configurare MySQL', 'Installare e configurare il database MySQL', true),
('Creare API REST', 'Sviluppare le API per gestire le task', true),
('Testare connessione Unity', 'Verificare che Unity si connetta correttamente al server', false);

-- Verifica che i dati siano stati inseriti
SELECT * FROM task;