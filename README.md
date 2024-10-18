# D2 Project

## `Representational State Transfer`
`Uniform Interface` `Stateless` `Cacheable` `Client-Server` `Layered System`


### `Uniform Interface`
The uniform interface is one of the core principles of REST, ensuring that the communication between the client and server is standardized and predictable. This principle is broken down into several aspects:

   - `Clearly Defined Interface between Client and Server`: The client and server communicate over a consistent, well-defined set of operations (typically using HTTP methods like `GET`, `POST`, `PUT`, `DELETE`). This uniformity means the client doesn’t need to know the details of the server's implementation.
   
   - `Identification of Resources`: Resources are identified using URIs (Uniform Resource Identifiers). In a RESTful system, everything is treated as a resource, and these resources are manipulated by their URI. For example, `/users/123` could represent a user with ID 123.
   
   - `Manipulation of Resources through Representations`: Clients interact with resources through representations (like JSON, XML, or HTML). A representation is a snapshot of the resource at a point in time. For example, when you `POST` or `PUT` data, you're sending a representation of the resource.
   
   - `Self-Descriptive Messages`: Each request from the client to the server should contain all the information the server needs to process it. The message includes information about how to interpret it (e.g., content type and method) and what to do with the resource (e.g., `DELETE /users/123`).
   
   - `HATEOAS (Hypermedia as the Engine of Application State)`: In REST, hypermedia (usually links) provides information on how to navigate the API. For example, after retrieving a list of users, the response could include links to related resources (e.g., user details, user posts). This reduces the need for hard-coded API knowledge.

### `Stateless`
   - The server does not store any state about the client session. Every request from the client must contain all the information needed to understand and process the request. This means that each request is independent, and the server doesn’t rely on previous interactions to complete the current one. 
   - This simplifies the server's logic and improves scalability, as it can handle requests without tracking client sessions. If a client needs to maintain state (like a shopping cart), that information would be sent with every request or stored on the client-side (like in a cookie or local storage).

### `Cacheable`
   - Responses from the server must define whether they can be cached, allowing clients or intermediaries (like proxies) to store the responses for later use, reducing the need for repetitive requests.
   - Cacheable responses include information about their cacheability through headers (e.g., `Cache-Control`, `Expires`). This principle improves network efficiency and reduces server load by allowing clients to reuse prior responses instead of constantly querying the server.

### `Client-Server`
   - REST architectures are designed with a clear separation of concerns between the client and the server. The client is responsible for the user interface and experience, while the server handles data and logic.
   - This separation allows each to evolve independently, as long as the interface (API contract) remains consistent. For example, a server-side update won't break the client-side functionality as long as the API stays the same.

### `Layered System`
   - A REST API should be designed as a layered system where the client doesn’t know whether it’s directly communicating with the server or an intermediary (e.g., a load balancer, caching proxy, or security layer).
   - This abstraction allows the system to be more scalable and modular. For example, you can introduce caching layers to improve performance, or security layers to handle authentication and authorization, without changing the client-server interaction.

### `Code on Demand (Optional)`
   - This is an optional feature of REST where the server can temporarily extend or customize the client’s functionality by sending executable code (like JavaScript).
   - For example, the server could send client-side scripts for additional functionality or UI components, which can be executed on the client. This flexibility, though optional, allows for dynamic behavior on the client-side without needing constant updates or deployments.