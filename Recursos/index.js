'use strict';
class Header {
    constructor(settings) {
        let obj = {
            title: settings.title ?? "Trabajo Práctico N.º 6",
            group: settings.group ?? "Resolución de Máximo Canedo",
            links: settings.links ?? [
                ["Primer Ejercicio", "./PrimerEjercicio/PrimerEjercicio.aspx"]
            ],
            otherLinks: settings.otherLinks ?? [
                ["Repositorio", "https://github.com/maximocanedo/PROGIII-TP6"],
                ["Foro", ""]
            ]
        };
        this.header = document.createElement("header");
        const title = document.createElement("span");
        title.classList.add("title");
        title.innerText = `${obj.title} · ${obj.group}`;
        this.header.append(title);
        obj.links.map(link => {
            const linkEl = document.createElement("a");
            linkEl.setAttribute("href", link[1]);
            linkEl.innerText = link[0];
            this.header.append(linkEl);
        });
        for (let i = 0; i < 1; i++) {
            const space = document.createElement("div");
            space.classList.add("space");
            this.header.append(space);
        }
        obj.otherLinks.map(link => {
            const linkEl = document.createElement("a");
            linkEl.setAttribute("href", link[1]);
            linkEl.innerText = link[0];
            this.header.append(linkEl);
        });
    }
    putOnPage() {
        document.body.prepend(this.header);
    }
}

window.MostrarMensaje = (mensaje) => {
    window.snackbar = new mdc.snackbar.MDCSnackbar.attachTo(document.querySelector('.mdc-snackbar'));
    window.snackbar.labelText = mensaje;
    window.snackbar.open();
};
window.onload = (() => {
    let header = new Header({
        title: "Trabajo Práctico N.º 6",
        group: "Grupo N.º 5",
        links: [
            ["Primer Ejercicio", "/PrimerEjercicio/PrimerEjercicio.aspx"],
            ["Segundo Ejercicio", "/SegundoEjercicio/Inicio.aspx"]
        ],
        otherLinks: [
            ["Repositorio", "https://github.com/maximocanedo/PROGIII-TP6"],
            ["Foro", "https://frgp.cvg.utn.edu.ar/mod/forum/discuss.php?d=157046"]
        ]
    });
    header.putOnPage();
    // Instantiate all Textfields
    document.querySelectorAll('.mdc-text-field').forEach(element => {
        mdc.textField.MDCTextField.attachTo(element);
    });
    // MDCButton
    document.querySelectorAll('.mdc-button').forEach(element => {
        let text = element.innerText;
        let ripple = document.createElement("span");
        ripple.classList.add("mdc-button__ripple");
        element.append(ripple);
        mdc.ripple.MDCRipple.attachTo(element);
    });
    window.snackbar = new mdc.snackbar.MDCSnackbar.attachTo(document.querySelector('.mdc-snackbar'));
    let input = document.querySelector('#tbMsj');
    input.addEventListener('change', () => {
        MostrarMensaje(input.value);
    });
    /**/
});