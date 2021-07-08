1. Unzip the repository
2. At the root directory, restore required packages by running:
   ```
   dotnet restore
   ```
3. Next, build the solution by running:
   ```
   dotnet build
   ```
4. Next, within the `\Hahn.ApplicatonProcess.February2021.Web\ClientApp` directory, launch the front end by running:
   ```
   npm start
   ```
5. Once the front end has started, within the `\Hahn.ApplicatonProcess.February2021.Web` directory, launch the back end by running:
   ```
   dotnet run
   ```
6. Launch [http://localhost:8080/] in your browser to view the Web UI

7. Launch [http://localhost:500/api] in your browser to view the API
8. Launch [http://localhost:500/swagger] in your browser to view the API documentation
