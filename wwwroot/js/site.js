document.addEventListener("DOMContentLoaded", () => {
    const sidebar = document.getElementById("app-sidebar");
    const sidebarToggle = document.getElementById("sidebar-toggle");
    const sidebarBackdrop = document.getElementById("sidebar-backdrop");
    const userToggle = document.getElementById("user-menu-toggle");
    const userMenu = document.getElementById("user-menu");

    const openSidebar = () => {
        sidebar?.classList.remove("-translate-x-full");
        sidebarBackdrop?.classList.remove("hidden");
        sidebarToggle?.setAttribute("aria-expanded", "true");
    };

    const closeSidebar = () => {
        sidebar?.classList.add("-translate-x-full");
        sidebarBackdrop?.classList.add("hidden");
        sidebarToggle?.setAttribute("aria-expanded", "false");
    };

    sidebarToggle?.addEventListener("click", () => {
        const isClosed = sidebar?.classList.contains("-translate-x-full");
        if (isClosed) {
            openSidebar();
        } else {
            closeSidebar();
        }
    });

    sidebarBackdrop?.addEventListener("click", closeSidebar);

    userToggle?.addEventListener("click", (event) => {
        event.stopPropagation();
        userMenu?.classList.toggle("hidden");
        userToggle.setAttribute("aria-expanded", String(!userMenu?.classList.contains("hidden")));
    });

    document.addEventListener("click", (event) => {
        if (!userMenu || !userToggle) {
            return;
        }

        const target = event.target;
        if (!(target instanceof Node)) {
            return;
        }

        if (!userMenu.contains(target) && !userToggle.contains(target)) {
            userMenu.classList.add("hidden");
            userToggle.setAttribute("aria-expanded", "false");
        }
    });

    iniciarBuscadores();
});

function normalizarBusqueda(texto) {
    return (texto || "")
        .normalize("NFD")
        .replace(/\p{M}/gu, "")
        .toLowerCase()
        .trim();
}

function iniciarBuscadores() {
    const formularios = document.querySelectorAll("[data-buscador]");
    if (formularios.length === 0) {
        return;
    }

    let indicePromise = null;
    const obtenerIndice = () => {
        if (!indicePromise) {
            indicePromise = fetch("/buscar/indice").then((respuesta) => {
                if (!respuesta.ok) {
                    throw new Error("No se pudo cargar el índice de búsqueda.");
                }
                return respuesta.json();
            });
        }
        return indicePromise;
    };

    const filtrar = (entradas, consulta) => {
        const q = normalizarBusqueda(consulta);
        if (q.length < 2) {
            return [];
        }

        return entradas
            .filter((entrada) => (entrada.textoBusqueda || "").includes(q))
            .sort((a, b) => {
                const tituloA = normalizarBusqueda(a.titulo);
                const tituloB = normalizarBusqueda(b.titulo);
                const pa = tituloA.startsWith(q) ? 0 : tituloA.includes(q) ? 1 : 2;
                const pb = tituloB.startsWith(q) ? 0 : tituloB.includes(q) ? 1 : 2;
                if (pa !== pb) {
                    return pa - pb;
                }
                if (a.tipo !== b.tipo) {
                    return a.tipo === "pagina" ? -1 : 1;
                }
                return tituloA.localeCompare(tituloB);
            })
            .slice(0, 8);
    };

    formularios.forEach((formulario) => {
        const campo = formulario.querySelector(".js-buscador-input");
        const lista = formulario.querySelector(".js-buscador-sugerencias");
        if (!(campo instanceof HTMLInputElement) || !(lista instanceof HTMLElement)) {
            return;
        }

        const ocultar = () => lista.classList.add("hidden");

        const pintar = (coincidencias) => {
            lista.replaceChildren();
            if (coincidencias.length === 0) {
                ocultar();
                return;
            }

            coincidencias.forEach((entrada) => {
                const item = document.createElement("li");
                const enlace = document.createElement("a");
                enlace.href = entrada.url;
                enlace.className = "block px-3 py-2 text-neutral-800 hover:bg-orange-50 hover:text-neutral-800";

                const etiqueta = document.createElement("p");
                etiqueta.className = "text-xs font-semibold tracking-wide text-udlap-naranja uppercase";
                etiqueta.textContent = entrada.tipo === "contacto" ? "Contacto" : entrada.seccion;

                const titulo = document.createElement("p");
                titulo.className = "font-medium text-neutral-900";
                titulo.textContent = entrada.titulo;

                enlace.append(etiqueta, titulo);
                item.appendChild(enlace);
                lista.appendChild(item);
            });
            lista.classList.remove("hidden");
        };

        campo.addEventListener("input", () => {
            const consulta = campo.value;
            if (normalizarBusqueda(consulta).length < 2) {
                ocultar();
                return;
            }

            obtenerIndice()
                .then((entradas) => pintar(filtrar(entradas, consulta)))
                .catch(() => ocultar());
        });

        campo.addEventListener("keydown", (evento) => {
            if (evento.key === "Escape") {
                ocultar();
            }
        });

        document.addEventListener("click", (evento) => {
            const destino = evento.target;
            if (!(destino instanceof Node) || formulario.contains(destino)) {
                return;
            }
            ocultar();
        });
    });
}
