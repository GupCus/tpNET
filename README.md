# TP IDE (.NET)

Sistema de planificación de viajes grupales y control de gastos

### 👥Integrantes

- 52818 - Barroso Bollero, Agustín
- 52216 - Ramos, Tomás
- 52634 - Gregoret, Facundo

**Cursando en:** UTN FRRo, Cátedra Tecnologías de Desarrollo de Software IDE (.NET), ISI 3EK01 2025.


## Proposal

### 📝 Descripción

Aplicación real: viajes de amigos, egresados, escapadas, viajes familiares  
**Usuarios:** Usuario común / Administrador del grupo

---

### ✅ Funcionalidades principales

- **Creación de grupos de viaje** (ej. “Viaje Bariloche 2025”)
- **Alta de participantes** dentro del grupo
- **Creación de plan** por día o actividad
- **Tareas compartidas** con responsables y fechas (comprar pasajes, hacer check-in)
- **Carga de gastos grupales** con:
  - Descripción, monto total, categoría (comida, transporte, etc.)
  - División automática o manual entre participantes
  - Cálculo de saldos individuales: quién le debe a quién
- **Recordatorios** de tareas o actividades del itinerario
- Mensajes o comentarios por gasto o tarea

---

### 📋 ABMs 

- Grupos de viaje
- Participantes
- Plan (día y actividad)
- Tareas
- Gastos
- Categorías de gasto

---

### 📊 Reportes

- Gasto total por persona y monto pagado por cada uno (gráfico de barras)
- Quién le debe a quién (gráfico de saldos y deudas cruzadas)
- Gastos por categoría (comida, transporte, alojamiento, etc.)

---

### 🔐 Requisitos técnicos y de arquitectura

- **Login** con rol común / administrador del grupo
- **Autorización:** solo el admin puede editar gastos y participantes
- **Validaciones:**
  - Monto positivo, participantes existentes
  - División exacta de gastos o aviso de redondeo

---

### 💡 Ideas extra

- Simulación de liquidación de gastos (qué transferencias hacer para saldar deudas)
- Ranking de “quién puso más” en el grupo
- Votación de actividades por miembro (opcional)
