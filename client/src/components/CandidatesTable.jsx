import React from 'react'
import { Link } from "react-router-dom";


const CandidatesTable = ({ candidates, history }) => {

    return (
        <table className="table">
            <thead>
                <tr>
                    <th scope="col">Nombre</th>
                    <th scope="col">Aspiración salarial</th>
                    <th scope="col">Email</th>
                    <th scope="col">Acciones</th>
                </tr>
            </thead>
            <tbody>
            {candidates.map((candidate) => (
                <tr key={candidate.id}>
                    <td>{candidate.name}</td>
                    <td>{candidate.salaryExpectation}</td>
                    <td>{candidate.email}</td>
                    <td>
                        <Link 
                          className="btn btn-primary"
                          to={`/subscription/${candidate.id}`}
                        >
                          Aplicar a vacantes
                        </Link>
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    )
}

export default CandidatesTable
