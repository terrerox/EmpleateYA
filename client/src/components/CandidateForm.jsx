import React, { useState } from 'react'
import candidatesService from '../helpers/candidatesService'
import swal from 'sweetalert';


const CandidateForm = ({ createCandidate }) => {
    const [candidate, setCandidate] = useState({
        name: '',
        salaryExpectation: 0,
        email: ''
    })

    const { name, salaryExpectation, email } = candidate

    const updateState = e => {
        setCandidate({
            ...candidate,
            [e.target.name]: e.target.value 
        })
    }

    const handleSubmit = (e) => {
      e.preventDefault()

      if (name.trim() === '' || name.trim() === '' || salaryExpectation === 0) return
      
      candidatesService.create({
        name,
        salaryExpectation: Number(candidate.salaryExpectation),
        email
      })
      .then(candidate => {
          swal("Candidato ingresado")
          createCandidate(candidate)
        })

      setCandidate({
        name: '',
        salaryExpectation: 0,
        email: ''
      })
    }
    return (
        <form className="form" onSubmit={handleSubmit}>
            <div className="row">
                <div className="col my-3">
                    <input
                        name="name"
                        className="form-control"
                        onChange={updateState}
                        value={name}
                        placeholder="Ingrese su nombre" 
                        autoFocus
                    />
                </div>
                <div className="col my-3">
                    <input
                        name="salaryExpectation"
                        className="form-control"
                        type="number"
                        onChange={updateState}
                        value={salaryExpectation}
                        placeholder="Ingrese aspiración salarial" 
                        autoFocus
                    /> 
                </div>
            </div>
            <div className="row">
                <div className="col my-3">
                    <input
                        name="email"
                        type="email"
                        className="form-control"
                        onChange={updateState}
                        value={email}
                        placeholder="Ingrese correo" 
                        autoFocus
                    /> 
                </div>
            </div>
            <button 
                type="submit"
                className="btn btn-primary"
            >
            Agregar candidato
            </button>
        </form>
    )
}

export default CandidateForm
