import React from 'react'

const JobsTable = ({ jobs, setIsUpdating, setJobToUpdate }) => {

    const updateJob = (job) => {
        setIsUpdating(true)
        setJobToUpdate(job)
    }
    return (
        <table className="table">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Salario</th>
                    <th scope="col">Estatus</th>
                    <th scope="col">Acciones</th>
                </tr>
            </thead>
            <tbody>
            {jobs.map((job) => (
                <tr key={job.id}>
                    <td>{job.name}</td>
                    <td>{job.salary}</td>
                    <td>{job.status === 1 ? 'Vacante' : 'Ocupado'}</td>
                    <td>
                        <a 
                          className="btn btn-primary"
                          onClick={() => updateJob(job)}
                        >
                          Actualizar
                        </a>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    )
}

export default JobsTable
