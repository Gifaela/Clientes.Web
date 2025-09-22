# 🌐 Clientes Frontend (ASP.NET MVC)

Este projeto implementa o **frontend** do sistema de clientes, consumindo o serviço **WCF** do backend.

---

## 🚀 Tecnologias
- ASP.NET MVC 5  
- Razor  
- Bootstrap  
- FontAwesome  
- Service Reference (consumo do WCF)

---

## 📂 Estrutura
- `Controllers/ClientesController.cs` → Consome o serviço WCF  
- `Views/Clientes/` → Views para CRUD de clientes  
- `Models/ClienteViewModel.cs` → Modelos da aplicação  
- `ClientesWcReference/` → Service Reference para o backend WCF  

---

## ⚙️ Configuração

1. Certifique-se de que o backend (WCF) está rodando.  
   - Exemplo: `http://localhost:62716/ClienteService.svc`

2. No Visual Studio, atualize o **Service Reference**:
   - Clique com o botão direito em `ClientesWcReference`  
   - Selecione **Update Service Reference**  
   - Confirme que a URL do serviço está correta  

3. Ajuste a connection string do **frontend** (se houver necessidade, como logs ou Identity).  
   - Por padrão, esse projeto consome apenas o serviço WCF, então o banco é acessado apenas pelo backend.

---

## ▶️ Executando

Abra a solução **Clientes.Web.sln** no Visual Studio e execute com **IIS Express**.  

A aplicação estará disponível em:  


http://localhost:49986/Clientes


---

## 🔗 Funcionalidades

- Listar clientes  
- Visualizar detalhes de cliente  
- Criar novo cliente  
- Editar cliente existente  
- Excluir cliente  

---

## 🧪 Testes

1. Rode o **backend (WCF)** primeiro.  
2. Depois rode o **frontend (MVC)**.  
3. Acesse no navegador:  


http://localhost:49986/Clientes

4. Você deve ver a lista de clientes retornada do WCF.  

---

## 📌 Observações

- O frontend depende do **backend WCF** para funcionar.  
- Repositório do backend: [Clientes Backend (WCF)](https://github.com/Gifaela/Clientes.WcService)  
- Caso mude a porta do backend, atualize a referência de serviço (`ClientesWcReference`).  
- O estilo visual utiliza **Bootstrap** e **FontAwesome**, podendo ser customizado facilmente.  
