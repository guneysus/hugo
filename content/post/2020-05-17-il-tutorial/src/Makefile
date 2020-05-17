IL := ilasm /nologo /quiet
ILDASM := ildasm

%.il: %.exe
	$(ILDASM) $< /OUT=$@ /TEXT
		
%.dll: %.il
	$(IL) /debug /dll $<

%.exe: %.il
	$(IL) /debug $<
	
clean:
	rm *.dll
	rm *.exe
	
.PHONY: $(ALL) default clean