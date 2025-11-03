using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskManagerExample : MonoBehaviour
{
    [Header("References")]
    public TaskManager taskManager;
    
    [Header("Test Data")]
    public bool runTestsOnStart = false;
    public float testDelay = 2f;
    
    private void Start()
    {
        if (taskManager == null)
        {
            taskManager = FindAnyObjectByType<TaskManager>();
            if (taskManager == null)
            {
                Debug.LogError("TaskManager not found in scene!");
                return;
            }
        }
        
        // Subscribe to events
        taskManager.OnTasksLoaded += OnTasksLoaded;
        taskManager.OnTaskCreated += OnTaskCreated;
        taskManager.OnTaskUpdated += OnTaskUpdated;
        taskManager.OnTaskDeleted += OnTaskDeleted;
        taskManager.OnError += OnError;
        
        if (runTestsOnStart)
        {
            StartCoroutine(RunTests());
        }
    }
    
    [ContextMenu("Test Server Connection")]
    public void TestServerConnection()
    {
        StartCoroutine(TestServerEndpoint());
    }
    
    private IEnumerator TestServerEndpoint()
    {
        string testUrl = taskManager.baseUrl.Replace("/api/tasks", "/api/test");
        Debug.Log($"🔍 Testing server at: {testUrl}");
        
        using (UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequest.Get(testUrl))
        {
            yield return request.SendWebRequest();
            
            if (request.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
            {
                Debug.Log($"✅ Server test successful: {request.downloadHandler.text}");
            }
            else
            {
                Debug.LogError($"❌ Server test failed: {request.error}");
            }
        }
    }
    
    private void OnDestroy()
    {
        if (taskManager != null)
        {
            taskManager.OnTasksLoaded -= OnTasksLoaded;
            taskManager.OnTaskCreated -= OnTaskCreated;
            taskManager.OnTaskUpdated -= OnTaskUpdated;
            taskManager.OnTaskDeleted -= OnTaskDeleted;
            taskManager.OnError -= OnError;
        }
    }
    
    private IEnumerator RunTests()
    {
        Debug.Log("🧪 Starting TaskManager tests...");
        
        yield return new WaitForSeconds(testDelay);
        
        // Test 1: Load all tasks
        Debug.Log("Test 1: Loading all tasks");
        taskManager.LoadAllTasks();
        yield return new WaitForSeconds(testDelay);
        
        // Test 2: Create a new task
        Debug.Log("Test 2: Creating a new task");
        taskManager.CreateTask("Test Task Unity", $"This is a test task created from Unity in {System.DateTime.Now}", false);
        yield return new WaitForSeconds(testDelay);
        
        // Test 3: Create another task
        Debug.Log("Test 3: Creating another task");
        taskManager.CreateTask("Completed Task", $"This task is already completed in {System.DateTime.Now}", true);
        yield return new WaitForSeconds(testDelay);
        
        // Test 4: Load tasks again to see new ones
        Debug.Log("Test 4: Loading tasks again");
        taskManager.LoadAllTasks();
        
        Debug.Log("🧪 Tests completed!");
    }
    
    #region Event Handlers
    
    private void OnTasksLoaded(List<Task> tasks)
    {
        Debug.Log($"📋 Tasks loaded: {tasks.Count}");
        foreach (Task task in tasks)
        {
            string status = task.completed ? "✅" : "⏳";
            Debug.Log($"  {status} [{task.id}] {task.title}: {task.description}");
        }
    }
    
    private void OnTaskCreated(Task task)
    {
        Debug.Log($"➕ Task created: [{task.id}] {task.title}");
    }
    
    private void OnTaskUpdated(Task task)
    {
        string status = task.completed ? "✅" : "⏳";
        Debug.Log($"🔄 Task updated: {status} [{task.id}] {task.title}");
    }
    
    private void OnTaskDeleted(string message)
    {
        Debug.Log($"🗑️ {message}");
    }
    
    private void OnError(string error)
    {
        Debug.LogError($"❌ Error: {error}");
    }
    
    #endregion
    
    #region Public Test Methods (can be called from UI buttons)
    
    [ContextMenu("Load All Tasks")]
    public void TestLoadAllTasks()
    {
        taskManager.LoadAllTasks();
    }
    
    [ContextMenu("Create Sample Task")]
    public void TestCreateTask()
    {
        string randomTitle = $"Sample Task {Random.Range(1, 1000)}";
        string description = "This is a sample task created from Unity";
        taskManager.CreateTask(randomTitle, description, false);
    }
    
    [ContextMenu("Create Completed Task")]
    public void TestCreateCompletedTask()
    {
        string randomTitle = $"Completed Task {Random.Range(1, 1000)}";
        string description = "This task is already completed";
        taskManager.CreateTask(randomTitle, description, true);
    }
    
    #endregion
}