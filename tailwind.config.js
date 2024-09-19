/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Views/**/*.cshtml',
    './wwwroot/**/*.html',
  ],
  darkMode: 'class', // Permite cambiar el modo claro/oscuro
  theme: {
    extend: {
      colors: {
        // Definimos colores para los modos claro y oscuro
        light: {
          background: '#f8fafc',
          primary: '#1f2937', // Gris oscuro para el texto
          secondary: '#3b82f6', // Azul para elementos destacados
          accent: '#10b981', // Verde para los botones
        },
        dark: {
          background: '#1f2937',
          primary: '#f8fafc', // Blanco para el texto
          secondary: '#2563eb', // Azul oscuro para elementos destacados
          accent: '#22d3ee', // Cian para los botones
        },
      },
    },
  },
  plugins: [
    require('@tailwindcss/forms'), // Plugin para formularios
  ],
};
