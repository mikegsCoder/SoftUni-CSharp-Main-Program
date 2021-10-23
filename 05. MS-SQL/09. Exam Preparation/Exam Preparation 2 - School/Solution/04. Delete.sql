DELETE
st
FROM StudentsTeachers AS st
JOIN Teachers AS t ON t.Id = st.TeacherId
WHERE t.Phone LIKE '%72%'

DELETE 
	Teachers 
	WHERE Phone LIKE '%72%'
