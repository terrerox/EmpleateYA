const jobsService = {}

jobsService.getAll = () => {
    return fetch('https://localhost:5001/job')
        .then( res => res.json())
        .then( res => res.data )
}

jobsService.getById = (id) => {
    return fetch(`https://localhost:5001/job/${id}`)
        .then( res => res.json())
}

jobsService.create = (job) => {
    return fetch('https://localhost:5001/job', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(job)
      })
      .then( res => res.json())
      .then( res => res.data )
}

jobsService.update = (job) => {
    return fetch('https://localhost:5001/job', {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(job)
      })
      .then( res => res.json())
      .then( res => res.data )
}

export default jobsService