const API = "https://localhost:7136/api/productos";

async function cargarProductos() {

    try {

        const response = await fetch(API);

        if (!response.ok) {
            throw new Error("Error al consultar API");
        }

        const productos = await response.json();

        let html = "";

        productos.forEach(p => {

            html += `
                <tr>
                    <td>${p.id}</td>
                    <td>${p.nombre}</td>
                    <td>${p.precio}</td>
                    <td>${p.stock}</td>
                </tr>
            `;
        });

        document.getElementById("tablaProductos").innerHTML = html;
    }
    catch (error) {

        console.error("ERROR:", error);

        alert("No se pudo conectar con la API");
    }
}

cargarProductos();  