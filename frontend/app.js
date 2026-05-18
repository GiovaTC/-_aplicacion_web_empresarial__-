const API = "https://localhost:5001/api/productos";

async function cargarProductos() {

    const response = await fetch(API);

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

async function guardar() {

    const producto = {

        nombre: document.getElementById("nombre").value,

        precio: parseFloat(document.getElementById("precio").value),

        stock: parseInt(document.getElementById("stock").value)
    };

    await fetch(API, {

        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(producto)
    });

    cargarProductos();
}

cargarProductos();