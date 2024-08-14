# Anonymous Real-Time Chat Application with Sentiment Analysis

This project is an anonymous real-time chat application that detects the sentiment of messages using Azure Text Analytics API. The application is built with ASP.NET Core 8, Vite, React, TypeScript, and CSS, and is deployed on Azure.

## Features

- **Anonymous Chat:** Users can participate in chat conversations without requiring authentication.
- **Real-Time Communication:** Leverages Azure SignalR Service for real-time messaging.
- **Sentiment Analysis:** Uses Azure Text Analytics API to analyze the sentiment of each message (positive, neutral, negative).
- **Scalable and Secure:** Deployed on Azure, ensuring scalability and security.

## Technologies Used

- **Backend:** ASP.NET Core 8
- **Frontend:** Vite, React, TypeScript, CSS
- **Real-Time Messaging:** Azure SignalR Service
- **Sentiment Analysis:** Azure Text Analytics API
- **Deployment Platform:** Azure

## Getting Started

### Prerequisites

- **Node.js:** Ensure you have Node.js installed.
- **.NET SDK:** Make sure the .NET SDK 8 is installed.
- **Azure Account:** You need an Azure account to deploy the application and use Azure services.

### Setup Instructions

1. **Clone the Repository:**

   ```bash
   git clone <repository-url>
   cd <repository-name>```

2. **Install Frontend Dependencies**

Navigate to the `client` directory where the React frontend is located, and install the necessary dependencies using Vite:

```bash
cd client
npm install
```

3. **Change Values Such As URLs**

4. **Set Up Azure Services**
   
Before running the application, set up the required Azure services:

**Azure SignalR Service**
1. Log in to the [Azure Portal](https://portal.azure.com).
1. Create a new Azure SignalR Service instance.
1. Retrieve the connection string from the SignalR Service's settings and note it down.
   
**Azure Text Analytics API**

1. In the Azure Portal, create a new Cognitive Services resource.
1. Choose the "Text Analytics" service.
1. Once created, get the endpoint URL and API key from the resource's "Keys and Endpoint" section.

Copy code
### 5. Store Secrets in Azure Key Vault

Securely store your sensitive information using Azure Key Vault to enhance the security of your application by keeping secrets out of your codebase.

#### Create a Key Vault

1. **Log in to Azure Portal:**
   - Visit [Azure Portal](https://portal.azure.com) and log in with your credentials.

2. **Create a New Key Vault Resource:**
   - Navigate to **"Create a resource"**.
   - Search for **"Key Vault"** and select **"Key Vault"** from the list.
   - Click **"Create"**.
   - Fill in the required information such as **Subscription**, **Resource Group**, **Key Vault Name**, and **Region**.
   - Click **"Review + Create"** and then **"Create"**.

#### Add Secrets to Key Vault

1. **Navigate to Your Key Vault:**
   - Once the Key Vault is created, go to your Key Vault by selecting it from the dashboard or through the **Resource Group**.

2. **Add Secrets:**
   - In the Key Vault, go to the **"Secrets"** section in the left-hand menu.
   - Click **"Generate/Import"** to add a new secret.
   - Add the following secrets one by one, providing a name and value for each:

   - **Name:** `SignalRConnectionString`
     **Value:** `<your-signalr-connection-string>`
     
   - **Name:** `TextAnalyticsEndpoint`
     **Value:** `<your-text-analytics-endpoint>`
     
   - **Name:** `CognitiveServicesApiKey`
     **Value:** `<your-congnitive-service-key>`

   - **Name:** `CognitiveServicesEndpoint`
     **Value:** `<your-congnitive-service-endpoint>`

   - **Name:** `DbConnection`
     **Value:** `<your-database-connection-string>`
     
   - Click **"Create"** for each secret to save them.

#### Configure Application to Access Key Vault

1. **Navigate to Your App Service:**
   - In the Azure Portal, go to your **App Service** that will host the backend of your application.

2. **Assign a Managed Identity:**
   - In the App Service menu, go to **"Identity"**.
   - Turn on the **System Assigned Managed Identity** and click **"Save"**.
   - Note down the Object ID assigned to your App Service.

3. **Grant Access to the Key Vault:**
   - Return to your Key Vault.
   - In the Key Vault menu, go to **"Access control"**.
   - Click **"Add"**.
   - Select **Add Role Assignment** in dropdown.
   - Choose **Key Vault Crypto User** and click **next**.
   - Choose **Assign access to Managed identity**
   - Click **Select members**
   - Choose your backend api resourse as a managed identity.
   - Click **"Select"** and then **"Review + asign"** to apply the policy.

  ### 6. Configure Access
**For Backend Part:**

Under "API", select "CORS".
Add allowed origins such as your frontend domain (https://your-frontend-domain.com).

In **SignalR** service asign **Contributor** role for a Web App Service that contains backend part.

In Sql Server int the left panell navigate to Security < Neworking.
Click **Add a firewall rule**, add name, and enter backend api in Start IP and End IP


## Links

Deployed Application - https://white-river-01e1da10f.5.azurestaticapps.net (deactivated)
