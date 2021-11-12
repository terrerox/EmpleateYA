import React from 'react'
import candidatesService from '../helpers/candidatesService'
import swal from 'sweetalert';

const HiringJobsTable = ({ hiringJobs, selectedCandidate }) => {

    const applyJob = (id) => {
        candidatesService.update({
            id: selectedCandidate.id,
            name: selectedCandidate.name,
            email: selectedCandidate.email,
            salaryExpectation: selectedCandidate.salaryExpectation,
            jobId: id
        })
        .then(() => swal("¡Hecho!", "Has aplicado a la vacante"))
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
            {hiringJobs.map((job) => (
                <tr key={job.id}>
                    <td>{job.name}</td>
                    <td>{job.salary}</td>
                    <td>Vacante</td>
                    <td>
                        <a 
                          className="btn btn-primary"
                          onClick={() => applyJob(job.id)}
                        >
                          Aplicar
                        </a>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    )
}

export default HiringJobsTable
