using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Script di test semplificato per verificare JsonUtility e le strutture dati
/// Questo script non richiede connessione al server e può essere usato per testare
/// la serializzazione/deserializzazione JSON in Unity
/// </summary>
public class JsonUtilityTest : MonoBehaviour
{
    [Header("Test Configuration")]
    public bool runTestOnStart = true;
    
    void Start()
    {
        if (runTestOnStart)
        {
            TestJsonSerialization();
        }
    }
    
    [ContextMenu("Run JSON Tests")]
    public void TestJsonSerialization()
    {
        Debug.Log("🧪 Iniziando test JsonUtility...");
        
        // Test 1: Serializzazione singola Task
        TestSingleTaskSerialization();
        
        // Test 2: Deserializzazione singola Task
        TestSingleTaskDeserialization();
        
        // Test 3: Array di Task (con wrapper)
        TestTaskArraySerialization();
        
        // Test 4: TaskResponse
        TestTaskResponseSerialization();
        
        Debug.Log("✅ Tutti i test JsonUtility completati!");
    }
    
    private void TestSingleTaskSerialization()
    {
        Debug.Log("📝 Test 1: Serializzazione singola Task");
        
        Task testTask = new Task("Test Task", "Questa è una task di test", false);
        testTask.id = 123;
        
        string json = JsonUtility.ToJson(testTask);
        Debug.Log($"Task serializzata: {json}");
        
        // Verifica che contenga i campi necessari
        if (json.Contains("Test Task") && json.Contains("123"))
        {
            Debug.Log("✅ Serializzazione Task: SUCCESS");
        }
        else
        {
            Debug.LogError("❌ Serializzazione Task: FAILED");
        }
    }
    
    private void TestSingleTaskDeserialization()
    {
        Debug.Log("📖 Test 2: Deserializzazione singola Task");
        
        string jsonTask = "{\"id\":456,\"title\":\"Task Deserializzata\",\"description\":\"Descrizione test\",\"completed\":true}";
        
        try
        {
            Task deserializedTask = JsonUtility.FromJson<Task>(jsonTask);
            
            Debug.Log($"Task deserializzata: ID={deserializedTask.id}, Title={deserializedTask.title}, Completed={deserializedTask.completed}");
            
            if (deserializedTask.id == 456 && deserializedTask.title == "Task Deserializzata" && deserializedTask.completed == true)
            {
                Debug.Log("✅ Deserializzazione Task: SUCCESS");
            }
            else
            {
                Debug.LogError("❌ Deserializzazione Task: FAILED - Dati non corrispondono");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ Deserializzazione Task: FAILED - {e.Message}");
        }
    }
    
    private void TestTaskArraySerialization()
    {
        Debug.Log("📋 Test 3: Array di Task (con TaskListWrapper)");
        
        // Crea alcune task di test
        Task[] testTasks = new Task[]
        {
            new Task("Task 1", "Prima task", false) { id = 1 },
            new Task("Task 2", "Seconda task", true) { id = 2 },
            new Task("Task 3", "Terza task", false) { id = 3 }
        };
        
        // Crea il wrapper
        TaskListWrapper wrapper = new TaskListWrapper(testTasks);
        
        // Serializza il wrapper
        string wrapperJson = JsonUtility.ToJson(wrapper);
        Debug.Log($"TaskListWrapper serializzato: {wrapperJson}");
        
        // Simula la risposta del server (solo l'array)
        string simulatedServerResponse = "[{\"id\":10,\"title\":\"Server Task\",\"description\":\"Dal server\",\"completed\":false}]";
        
        // Test del wrapping per JsonUtility
        string wrappedJson = "{\"tasks\":" + simulatedServerResponse + "}";
        
        try
        {
            TaskListWrapper deserializedWrapper = JsonUtility.FromJson<TaskListWrapper>(wrappedJson);
            List<Task> taskList = deserializedWrapper.ToList();
            
            Debug.Log($"Array deserializzato: {taskList.Count} task trovate");
            foreach (Task task in taskList)
            {
                Debug.Log($"  - {task.title} (ID: {task.id})");
            }
            
            Debug.Log("✅ Array Task con wrapper: SUCCESS");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ Array Task con wrapper: FAILED - {e.Message}");
        }
    }
    
    private void TestTaskResponseSerialization()
    {
        Debug.Log("⚠️ Test 4: TaskResponse (gestione errori)");
        
        string errorJson = "{\"error\":\"Task non trovata\",\"message\":\"Errore di test\",\"details\":\"Dettagli aggiuntivi\"}";
        
        try
        {
            TaskResponse errorResponse = JsonUtility.FromJson<TaskResponse>(errorJson);
            
            Debug.Log($"Errore deserializzato: {errorResponse.error} - {errorResponse.message}");
            
            if (!string.IsNullOrEmpty(errorResponse.error))
            {
                Debug.Log("✅ TaskResponse: SUCCESS");
            }
            else
            {
                Debug.LogError("❌ TaskResponse: FAILED");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ TaskResponse: FAILED - {e.Message}");
        }
    }
    
    [ContextMenu("Test Task Creation")]
    public void TestTaskCreation()
    {
        Debug.Log("🔨 Test creazione Task...");
        
        Task newTask = new Task("Task da Unity", "Creata programmaticamente", false);
        
        Debug.Log($"Task creata: {newTask.title}");
        Debug.Log($"Descrizione: {newTask.description}");
        Debug.Log($"Completata: {newTask.completed}");
        Debug.Log($"ID: {newTask.id} (dovrebbe essere 0 finché non assegnato dal server)");
        
        string json = JsonUtility.ToJson(newTask, true); // pretty print
        Debug.Log($"JSON per il server:\n{json}");
    }
    
    [ContextMenu("Simulate Server Response")]
    public void SimulateServerResponse()
    {
        Debug.Log("🖥️ Simulazione risposta server...");
        
        // Simula una tipica risposta del server con multiple task
        string simulatedResponse = @"[
            {""id"":1,""title"":""Imparare Unity"",""description"":""Studiare i fondamentali"",""completed"":false},
            {""id"":2,""title"":""Configurare MySQL"",""description"":""Setup database"",""completed"":true},
            {""id"":3,""title"":""Testare API"",""description"":""Verificare connessioni"",""completed"":false}
        ]";
        
        Debug.Log("Risposta server simulata:");
        Debug.Log(simulatedResponse);
        
        // Testa il parsing come farebbe TaskManager
        try
        {
            string wrappedJson = "{\"tasks\":" + simulatedResponse + "}";
            TaskListWrapper wrapper = JsonUtility.FromJson<TaskListWrapper>(wrappedJson);
            List<Task> tasks = wrapper.ToList();
            
            Debug.Log($"✅ Parsed {tasks.Count} tasks:");
            foreach (Task task in tasks)
            {
                string status = task.completed ? "✅" : "⏳";
                Debug.Log($"  {status} [{task.id}] {task.title}: {task.description}");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"❌ Parsing failed: {e.Message}");
        }
    }
}