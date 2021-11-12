import React, { useState, useEffect } from 'react'
import candidatesService from '../helpers/candidatesService'

import CandidateForm from '../components/CandidateForm'
import CandidatesTable from '../components/CandidatesTable'

const Candidates = () => {
    const [candidates, setCandidates] = useState([])

    useEffect(() => {
        candidatesService.getAll()
            .then(candidates => {
                setCandidates(candidates)
            })
    }, [])

    const createCandidate = candidate => {
        setCandidates([ ...candidates, candidate ]);
    }
    return (
        <div className="container">
            <div className="row">
                <div className="col-md-6">
                    <CandidateForm 
                        createCandidate={createCandidate}
                    />
                </div>
                <div className="col-md-6">
                    <CandidatesTable
                        candidates={candidates}
                    /> 
                </div>
            </div>
        </div>
    )
}

export default Candidates
