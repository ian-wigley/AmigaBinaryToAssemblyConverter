import pandas as pd


def check_number_of_words(result, size) -> int:
    if result["A"].values[0] != "":
        size = 2
        if result["B"].values[0] != "":
            size = 2
            if result["C"].values[0] != "":
                size = 4
                if result["d"].values[0] != "":
                    size = 6
    return size

def write_results(output) -> None:
    with open('compare_updated_68000_codes.txt', 'w+', encoding='utf-8') as temp_two:
        for items in output:
            temp_two.write('%s\n' %items)

if __name__ == '__main__':

    text_df = pd.read_csv("missing_codes.txt")
    todo_list = list(text_df["Code"].unique())
    todo_list.sort()

    dis_code = pd.read_csv("first_demo_dis.csv", delimiter="¬")
    dis_code = dis_code.fillna('')

    output = []
    for item in todo_list:

        if item == "4220":
            stop = True

        item: str = str(item)
        _ = item.lower()
        result = dis_code.query("Code == @_")
        size = 1
        if(len(result) > 0):
            size = check_number_of_words(result, size)
            col_e = result["E"].values[0]
            col_f = result["F"].values[0]
            split_index = col_f.find(",")
            temp_one = ""
            temp_two = col_f
            if split_index > -1:
                temp_one = col_f[0:split_index]
                temp_two = col_f[split_index:len(col_f)]
            output.append(f"<code>{item[0:2]}¬{item[2:4]}¬{col_e}¬{size}¬{temp_one}¬¬{temp_two}¬</code>")
        else:
            output.append(f"<code>{item[0:2]}¬{item[2:4]}¬ILLEGAL¬{size}¬¬¬¬</code>")

    write_results(output)

    print("Done!")
