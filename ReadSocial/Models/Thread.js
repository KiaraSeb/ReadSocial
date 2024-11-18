const { DataTypes } = require('sequelize');
const sequelize = require('../database'); // Importa tu configuración de la base de datos

const Thread = sequelize.define('Thread', {
    ThreadId: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true
    },
    Title: {
        type: DataTypes.STRING(100),
        allowNull: false
    },
    Description: {
        type: DataTypes.TEXT,
        allowNull: true
    },
    CreatedAt: {
        type: DataTypes.DATE,
        defaultValue: DataTypes.NOW
    }
}, {
    tableName: 'Threads',
    timestamps: false
});

module.exports = Thread;
